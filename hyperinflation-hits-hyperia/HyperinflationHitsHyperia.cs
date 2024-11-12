using System;

public static class CentralBank
{
    public static string DisplayDenomination(long @base, long multiplier)
    {
        try {
            var result = checked(@base * multiplier);

            return $"{result}";
        } catch (OverflowException) {
            return "*** Too Big ***";            
        }
    }

    public static string DisplayGDP(float @base, float multiplier)
    {
        var result = @base * multiplier;

        return float.IsInfinity(result)
            ? "*** Too Big ***"
            : $"{result}";
    }

    public static string DisplayChiefEconomistSalary(decimal salaryBase, decimal multiplier)
    {
        try {
            var result = salaryBase * multiplier;

            return $"{result}";
        } catch (OverflowException) {
            return "*** Much Too Big ***";            
        }
    }
}
