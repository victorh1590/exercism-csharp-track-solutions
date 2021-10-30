using System;

public class SpiralMatrix
{
    public static int[,] GetMatrix(int size)
    {
        if (size == 1) return new [,]{ {1} };
        
        int [,] matrix = new int[size,size];
        int counter = 1, line = 0, column = 0;
        
        bool NumbersLeft() => counter <= (size * size);
        
        void Line()
        {
            while (column < size && matrix[line, column] == 0)
                matrix[line, column++] = counter++;
            column--;
            line++;
        }

        void Column()
        {
            while (line < size && matrix[line, column] == 0)
                matrix[line++, column] = counter++;
            column--;
            line--;
        }

        void ReversedLine()
        {
            while (column >= 0 && matrix[line, column] == 0)
                matrix[line, column--] = counter++;
            column++;
            line--;
        }

        void ReversedColumn()
        {
            while (line >= 0 && matrix[line, column] == 0)
                matrix[line--, column] = counter++;
            line++;
            column++;
        }

        while (NumbersLeft())
        {
            Line();
            if (!NumbersLeft()) break;
            
            Column();
            if (!NumbersLeft()) break;
            
            ReversedLine();
            if (!NumbersLeft()) break;
            
            ReversedColumn();
        }

        return matrix;
    }
}
