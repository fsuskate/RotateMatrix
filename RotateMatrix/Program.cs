using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RotateMatrix
{
    class Program
    {
        public static void rotateMatrix90CounterClockwiseEx(int[,] source, out int[,] dest, int dimension)
        {
            dest = new int[dimension, dimension];
            for (int row = 0; row < dimension; row++)
            {
                for (int col = 0; col < dimension; col++)
                {
                    // Flip rows and cols in the destination matrix dest[col, row]
                    // To get the source column, calculate the inverted column index 
                    // |column - (dimension - 1)| = inverted column number
                    dest[col, row] = source[row, Math.Abs(col - (dimension - 1))];
                }
            }
        }

        public static void rotateMatrix90CounterClockwiseInPlace(int[,] source, int dimension)
        {
            for (int x = 0; x < dimension / 2; x++)
            {
                int xIndex = dimension - x - 1;

                for (int y = x; y < xIndex; y++)
                {
                    int yIndex = dimension - y - 1;

                    int temp = source[x, y];             // temp        <- upper left
                    source[x, y] = source[y, xIndex];        // upper left  <- upper right
                    source[y, xIndex] = source[xIndex, yIndex];   // upper right <- lower right 
                    source[xIndex, yIndex] = source[yIndex, x];        // lower right <- lower left  
                    source[yIndex, x] = temp;                     // lower left  <- temp
                }
            }
        }

        public static void printMatrix(int[,] matrix, int dim)
        {
            for (int r = 0; r < dim; r++)
            {
                for (int c = 0; c < dim; c++)
                {
                    Console.Write($"{matrix[r, c]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            int[,] dest;
            int[,] fours = { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 15, 16 } };
            printMatrix(fours, 4);

            rotateMatrix90CounterClockwiseEx(fours, out dest, 4);
            printMatrix(dest, 4);

            int[,] dest2;
            rotateMatrix90CounterClockwiseEx(dest, out dest2, 4);
            printMatrix(dest2, 4);

            int[,] dest3;
            rotateMatrix90CounterClockwiseEx(dest2, out dest3, 4);
            printMatrix(dest3, 4);

            int[,] dest4;
            rotateMatrix90CounterClockwiseEx(dest3, out dest4, 4);
            printMatrix(dest4, 4);

            for (int i = 0; i < 4; i++)
            {
                rotateMatrix90CounterClockwiseInPlace(fours, 4);
                printMatrix(fours, 4);
            }
        }
    }
}
