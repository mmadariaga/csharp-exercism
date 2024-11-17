using System;
public struct CurrencyAmount
{
    private decimal amount;
    private string currency;

    public CurrencyAmount(decimal amount, string currency)
    {
        this.amount = amount;
        this.currency = currency;
    }

    private static void assertSameCurrency(CurrencyAmount a, CurrencyAmount b)
    {
        if (a.currency != b.currency) {
            throw new ArgumentException();
        }
    }

    // equality operators
    public static bool operator == (CurrencyAmount a, CurrencyAmount b)
    {
        assertSameCurrency(a, b);

        return a.amount == b.amount;
    }

    public static bool operator != (CurrencyAmount a, CurrencyAmount b)
    {
        return !(a == b);
    }

    public override bool Equals(object obj)
    {
        if (obj is CurrencyAmount other)
        {
            return this == other;
        }

        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(amount, currency);
    }

    // comparison operators
    public static bool operator > (CurrencyAmount a, CurrencyAmount b)
    {
        assertSameCurrency(a, b);

        return a.amount > b.amount;
    }

    public static bool operator < (CurrencyAmount a, CurrencyAmount b)
    {
        return !(a > b) && !(a == b);
    }

    // arithmetic operators
    public static CurrencyAmount operator + (CurrencyAmount a, CurrencyAmount b)
    {
        assertSameCurrency(a, b);

        return new CurrencyAmount(a.amount + b.amount, a.currency);
    }

    public static CurrencyAmount operator - (CurrencyAmount a, CurrencyAmount b)
    {
        assertSameCurrency(a, b);

        return new CurrencyAmount(a.amount - b.amount, a.currency);
    }

    public static CurrencyAmount operator * (CurrencyAmount a, decimal multiplier)
    {
        return new CurrencyAmount(a.amount * multiplier, a.currency);
    }

    public static CurrencyAmount operator * (decimal multiplier, CurrencyAmount a)
    {
        return a * multiplier;
    }

    public static CurrencyAmount operator / (CurrencyAmount a, decimal divider)
    {
        if (divider == 0) {
            throw new DivideByZeroException();
        }

        return new CurrencyAmount(a.amount / divider, a.currency);
    }

    // type conversion operators
    public static explicit operator double (CurrencyAmount a)
    {
        return (double) a.amount;
    }

    public static implicit operator decimal (CurrencyAmount a)
    {
        return a.amount;
    }
}
