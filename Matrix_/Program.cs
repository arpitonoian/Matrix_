using System;

namespace Matrix_
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix matrix = new Matrix();
            int scalar = 0;
            try
            {
                Console.WriteLine("Please enter row: Matrix-1");
                matrix.row1 = int.Parse(Console.ReadLine());

                Console.WriteLine("Please enter column: Matrix-1");
                matrix.column1 = int.Parse(Console.ReadLine());

                Console.WriteLine("Please enter row :Matrix-2");
                matrix.row2 = int.Parse(Console.ReadLine());

                Console.WriteLine("Please enter column:Matrix-2");
                matrix.column2 = int.Parse(Console.ReadLine());

                Console.WriteLine("Please enter scalar value");
                scalar = int.Parse(Console.ReadLine());
            }

            catch (FormatException)
            {
                Console.WriteLine("Unable to convert.");
                return;
            }
            catch (OverflowException)
            {
                Console.WriteLine("'{0}' is out of range of the Int32 type.");
                return;
            }

            int[,] matrix1 = new int[matrix.row1, matrix.column1];
            int[,] matrix2 = new int[matrix.row2, matrix.column2];
            int[,] NewMatrix1 = CreatMatrix(matrix.row1, matrix.column1, matrix1);

            Console.WriteLine("**********  first matrix  ************");
            matrix.PrintMatrix(matrix.row1, matrix.column1, matrix1);
            int[,] NewMatrix2 = CreatMatrix(matrix.row2, matrix.column2, matrix2);
            Console.WriteLine();
            Console.WriteLine("**********  second matrix  ************");
            matrix.PrintMatrix(matrix.row2, matrix.column2, matrix2);
            Console.WriteLine();
            if (matrix.row1 == matrix.row2 && matrix.column1 == matrix.column2)
            {
                Console.WriteLine("***** Addition *****");
                int[,] AddMatrix = AdditionMatrix(matrix1, matrix2, matrix.row1, matrix.column1);
                matrix.PrintMatrix(matrix.row1, matrix.column1, AddMatrix);
            }
            else
            {
                Console.WriteLine(" Matrixes cannot be added, they do not have the same number of rows or columns");
                Console.WriteLine();
            }

            if (matrix.column1 != matrix.row2)
            {
                Console.WriteLine("Two Matrices cannot be multiplied:row != column");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("***** Multiplication ******");
                int[,] MultiplicationMatrix = Multiplication(matrix.row1, matrix.column1, matrix.row2, matrix.column2, matrix1, matrix2);
                matrix.PrintMatrix(matrix.row1, matrix.column2, MultiplicationMatrix);
            }

            Console.WriteLine("******* Scalar multiplication *********");
            int[,] Scalar = ScalarMatrix(matrix1, matrix.row1, matrix.column1, scalar);
            matrix.PrintMatrix(matrix.row1, matrix.column1, Scalar);

            int[,] Transpose = TransposeMatrix(matrix1, matrix.row1, matrix.column1);
            Console.WriteLine("******* Transpose Matrix *******");
            matrix.PrintMatrix(matrix.column1, matrix.row1, Transpose);

            int maxElement = MaxElementMatrix(matrix.row1, matrix.column1, NewMatrix1);
            Console.WriteLine("Max Element= " + maxElement);

            int minElement = MinElementMatrix(matrix.row1, matrix.column1, NewMatrix1);
            Console.WriteLine("Min Element= " + minElement);
        }

        static int[,] CreatMatrix(int row, int column, int[,] matrix)
        {
            Random rnd = new Random();
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    matrix[i, j] = rnd.Next(10);
                }
            }
            return matrix;
        }


