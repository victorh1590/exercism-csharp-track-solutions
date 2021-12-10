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

    private static void ErrorIfDifferentCurrency(CurrencyAmount amountA, CurrencyAmount amountB)
    {
        if (amountA.currency != amountB.currency) 
            throw new ArgumentException(
                "Currencies don't match." + 
                $"{amountA.currency} != {amountB.currency}");
    }

    public static bool operator ==(CurrencyAmount amountA, CurrencyAmount amountB)
    {
        ErrorIfDifferentCurrency(amountA, amountB);
        return amountA.amount == amountB.amount;
    }

    public static bool operator !=(CurrencyAmount amountA, CurrencyAmount amountB)
    {
        ErrorIfDifferentCurrency(amountA, amountB);
        return !(amountA == amountB);
    }

    public static bool operator >(CurrencyAmount amountA, CurrencyAmount amountB)
    {
        ErrorIfDifferentCurrency(amountA, amountB);
        return amountA.amount > amountB.amount;
    }
    
    public static bool operator <(CurrencyAmount amountA, CurrencyAmount amountB)
    {
        ErrorIfDifferentCurrency(amountA, amountB);
        return amountA.amount < amountB.amount;
    }

    public static CurrencyAmount operator +(CurrencyAmount amountA, CurrencyAmount amountB)
    {
        ErrorIfDifferentCurrency(amountA, amountB);
        return new CurrencyAmount
        {
            amount = amountA.amount + amountB.amount,
            currency = amountA.currency
        };
    }
    
    public static CurrencyAmount operator -(CurrencyAmount amountA, CurrencyAmount amountB)
    {
        ErrorIfDifferentCurrency(amountA, amountB);
        return new CurrencyAmount
        {
            amount = amountA.amount + (-amountB.amount),
            currency = amountA.currency
        };
    }
    
    public static CurrencyAmount operator *(CurrencyAmount amountA, CurrencyAmount amountB)
    {
        ErrorIfDifferentCurrency(amountA, amountB);
        return new CurrencyAmount
        {
            amount = amountA.amount * amountB.amount,
            currency = amountA.currency
        };
    }
    
    public static CurrencyAmount operator /(CurrencyAmount amountA, CurrencyAmount amountB)
    {
        ErrorIfDifferentCurrency(amountA, amountB);
        return new CurrencyAmount
        {
            amount = amountA.amount / (-amountB.amount),
            currency = amountA.currency
        };
    }
    
    public static explicit operator Double(CurrencyAmount amountA) 
        => Convert.ToDouble(amountA.amount);

    public static implicit operator Decimal(CurrencyAmount amountA)
        => Convert.ToDecimal(amountA.amount);
}
