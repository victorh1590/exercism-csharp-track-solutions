using System;

public class Queen
{
    public Queen(int row, int column)
    {
        Row = row;
        Column = column;
    }

    public int Row { get; }
    public int Column { get; }
}

public static class QueenAttack
{
    public static bool CanAttack(Queen white, Queen black)
    {
        TestOverlap(white, black);
        return white.Row == black.Row || 
               white.Column == black.Column || 
               white.Row + white.Column == black.Row + black.Column ||
               Math.Abs(white.Row - white.Column) == Math.Abs(black.Row - black.Column);
    }

    public static void TestOverlap(Queen white, Queen black)
    {
        if (white.Row == black.Row && white.Column == black.Column) throw new ArgumentException();
    }

    public static Queen Create(int row, int column)
    {
        if (row is > 7 or < 0 || column is > 7 or < 0) throw new ArgumentOutOfRangeException();
        return new Queen(row, column);
    }
}