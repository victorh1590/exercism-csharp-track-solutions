using System;

public class SpiralMatrix
{
    // public delegate void produceColumnAndReversedLine(int size);
    // public delegate void produceReversedColumnAndLine(int size);
    public static int[,] GetMatrix(int size)
    {
        if (size == 1) return new [,]{ {1} };
        
        int [,] matrix = new int[size,size];
        int counter = 1, line = 0, column = 0;

        // int sizeDup = size - 2;
        bool NumbersLeft() => counter <= (size * size);

        while (NumbersLeft())
        {
            while (column < size && matrix[line, column] == 0)
            {
                matrix[line, column++] = counter++;
            }

            if (!NumbersLeft()) break;
            column--;
            line++;

            while (line < size && matrix[line, column] == 0)
            {
                matrix[line++, column] = counter++;
            }

            if (!NumbersLeft()) break;
            column--;
            line--;
            while (column >= 0 && matrix[line, column] == 0)
            {
                matrix[line, column--] = counter++;
            }

            if (!NumbersLeft()) break;
            column++;
            line--;

            while (line >= 0 && matrix[line, column] == 0)
            {
                matrix[line--, column] = counter++;
            }

            line++;
            column++;
            sizeDup--;
        }
        

        return matrix;
    }
    
    
    // produceColumnAndReversedLine operation1 = produceColumn;
    //         produceColumnAndReversedLine operation2 = produceReversedLine;
    //         produceColumnAndReversedLine combined = operation1 + operation2;
    //
    //         produceReversedColumnAndLine operation3 = produceReversedColumn;
    //         produceReversedColumnAndLine operation4 = produceLine;
    //         produceReversedColumnAndLine combined2 = operation3 + operation4;
    //
    //
    //         void produceLine(int size)
    //         {
    //             while (column <= size - 1)
    //             {
    //                 if (matrix[line, ++column] != 0) break;
    //                 matrix[line, column] = counter++;
    //             }
    //             line++;
    //         }
    //         
    //         void produceColumn(int size)
    //         {
    //             while (line <= size - 1)
    //             {
    //                 if (matrix[++line, column] != 0) break;
    //                 matrix[line, column] = counter++;
    //             }
    //             column--;
    //         }
    //
    //         void produceReversedLine(int size)
    //         {
    //             while (column > 0)
    //             {
    //                 if (matrix[line, --column] != 0) break;
    //                 matrix[line, column] = counter++;
    //             }
    //             line--;
    //         }
    //         
    //         void produceReversedColumn(int size)
    //         {
    //             while (line > 0)
    //             {
    //                 if (matrix[--line, column] != 0) break;
    //                 matrix[line, column] = counter++;
    //             }
    //             column++;
    //         }
    //
    //         produceLine(size);
    //
    //         bool flip_flop = false;
    //
    //         for (int sizeDup = size; sizeDup > 0; sizeDup--)
    //         {
    //             if (!flip_flop)
    //             {
    //                 combined.Invoke(--sizeDup);
    //                 flip_flop = true;
    //                 continue;
    //             }
    //
    //             combined2.Invoke(--sizeDup);
    //             flip_flop = false;
    //         }

}
