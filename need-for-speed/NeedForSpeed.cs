using System;

class RemoteControlCar
{
    private int _drivenDistance = 0;
    private int _battery = 100;

    private int _speed;
    private int _batteryDrain;

    public RemoteControlCar(
        int speed,
        int batteryDrain
    ) {
        this._speed = speed;
        this._batteryDrain = batteryDrain;
    }

    public bool BatteryDrained()
    {
        return _battery < _batteryDrain;
    }

    public int DistanceDriven()
    {
        return _drivenDistance;
    }

    public void Drive()
    {
        if (BatteryDrained()) {
            return;
        }

        _battery -= _batteryDrain;
        _drivenDistance += _speed;
    }

    public static RemoteControlCar Nitro()
    {
        return new RemoteControlCar(
            speed: 50,
            batteryDrain: 4
        );
    }
}

class RaceTrack
{
    private int _distance;

    public RaceTrack(
        int distance
    ) {
        this._distance = distance;
    }

    public bool TryFinishTrack(RemoteControlCar car)
    {
        while (true) {

            if (car.DistanceDriven() >= _distance) {
                return true;
            }

            if (car.BatteryDrained()) {
                return false;
            }

            car.Drive();
        }
    }
}
