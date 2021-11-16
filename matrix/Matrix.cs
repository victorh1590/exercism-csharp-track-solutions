using System;
using System.Collections.Generic;
using System.Linq;

public class Matrix
{
    private int[][] _rows;
    private int[][] _cols;
    
    public Matrix(string input)
    {
        _rows = BuildRowMatrix(input);
        _cols = BuildColumnMatrix(_rows);
    }

    private int[][] BuildRowMatrix(string input)
    {
        string[] matrix = input.Split('\n');
        List<string[]> rows = matrix.Select(line => line.Split(' ')).ToList();
        return rows.Select(row => row.Select(int.Parse).ToArray()).ToArray();
    }

    private int[][] BuildColumnMatrix(int[][] rowMatrix)
    {
        List<int[]> columnMatrix = new();
        for (int row = 0; row < rowMatrix.Length; row++)
        {
            for (int column = 0; column < rowMatrix[row].Length; column++)
            {
                if(columnMatrix.ElementAtOrDefault(column) == default) 
                    columnMatrix.Add(new int[rowMatrix.Length]);
                columnMatrix[column][row] = rowMatrix[row][column];
            }
        }
        return columnMatrix.ToArray();
    }

    public int Rows => _rows.Length;
    public int Cols => _cols.Length;
    public int[] Row(int row) => _rows[row - 1];
    public int[] Column(int col) => _cols[col - 1];
}