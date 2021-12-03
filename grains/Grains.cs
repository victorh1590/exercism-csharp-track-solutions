using System;
using System.Numerics;

public static class Grains
{
    private const int NumSquares = 64;
    private const int BaseNum = 2;
    private static BigInteger SumOfSquares(int numSquares, ulong baseNum) 
        => (BigInteger.Pow(baseNum, numSquares) - 1 / (baseNum - 1));
    private static readonly Lazy<BigInteger> SumAllSquares = new(SumOfSquares(NumSquares, BaseNum));

    public static ulong Square(int n)
    {
        if (n is <= 0 or > 64) throw new ArgumentOutOfRangeException();
        return (ulong)Math.Pow(2, n-1);
    }
    public static ulong Total() => (ulong)SumAllSquares.Value;
}