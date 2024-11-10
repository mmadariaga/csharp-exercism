using System;

public static class TelemetryBuffer
{
    public static byte[] ToBuffer(long reading)
    {
        var prefixByte = GetPrefixByte(reading);

        byte[] response = new byte[9];
        response[0] = prefixByte;

        switch(prefixByte) {
            case 2:
                BitConverter.GetBytes((ushort) reading).CopyTo(response, 1);
                break;
            case 4:
                BitConverter.GetBytes((uint) reading).CopyTo(response, 1);
                break;
            case 256 - 2:
                BitConverter.GetBytes((short) reading).CopyTo(response, 1);
                break;
            case 256 - 4:
                BitConverter.GetBytes((int) reading).CopyTo(response, 1);
                break;
            case 256 - 8:
                BitConverter.GetBytes(reading).CopyTo(response, 1);
                break;
        }

        return response;
    }

    public static long FromBuffer(byte[] buffer)
    {
        switch(buffer[0]) {
            case 2:
                return BitConverter.ToUInt16(buffer, 1);
            case 4:
                return BitConverter.ToUInt32(buffer, 1);
            case 256 - 2:
                return BitConverter.ToInt16(buffer, 1);
            case 256 - 4:
                return BitConverter.ToInt32(buffer, 1);
            case 256 - 8:
                return BitConverter.ToInt64(buffer, 1);
            default:
                return 0;
        }
    }

    private static byte GetPrefixByte(long reading)
    {
        if (reading >= 0) {
            if (UInt16.MaxValue >= reading) {
                return 2;
            }

            if (Int32.MaxValue >= reading) {
                return 256 - 4;
            }

            if (UInt32.MaxValue >= reading) {
                return 4;
            }

        } else {
            if (Int16.MinValue <= reading) {
                return 256 - 2;
            }

            if (Int32.MinValue <= reading) {
                return 256 - 4;
            }
        }

        return 256 - 8;
    }
}
