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


        static int MaxElementMatrix(int row, int column, int[,] matrix)
        {
            int maxElement = int.MinValue;

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    if (matrix[i, j] > maxElement)
                        maxElement = matrix[i, j];
                }
            }
            return maxElement;
        }

        static int MinElementMatrix(int row, int column, int[,] matrix)
        {
            int minElement = int.MaxValue;

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    if (matrix[i, j] < minElement)
                        minElement = matrix[i, j];
                }
            }
            return minElement;
        }

        static int[,] AdditionMatrix(int[,] Matrix1, int[,] Matrix2, int row, int column)
        {
            int[,] AddMatrix = new int[row, column];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    AddMatrix[i, j] = Matrix1[i, j] + Matrix2[i, j];
                }
            }
            return AddMatrix;
        }

        static int[,] Multiplication(int row1, int column1, int row2, int column2, int[,] matrix1, int[,] matrix2)
        {
            int[,] NewMatrix = new int[row1, column2];
            int t = 0;
            int Sum = 0;
            int index = 0;

            for (int i = 0; i < row1; i++)
            {
                t = 0;
                index = 0;
                while (t < column2)
                {
                    Sum = 0;
                    for (int j = 0; j < column1;)
                    {
                        for (int c = 0; c < row2; c++)
                        {
                            Sum += matrix1[i, j] * matrix2[c, t];
                            j++;
                        }
                        t++;
                    }
                    NewMatrix[i, index] = Sum;
                    index++;
                }
            }
            return NewMatrix;
        }

        static int[,] ScalarMatrix(int[,] matrix, int row, int column, int scalar)
        {
            int[,] NewMatrix = new int[row, column];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    NewMatrix[i, j] = scalar * matrix[i, j];
                }
            }
            return NewMatrix;
        }

        static int[,] TransposeMatrix(int[,] matrix, int row, int column)
        {
            int[,] TransposeMatrix = new int[column, row];
            int newColumn = 0;
            for (int i = 0; i < row; i++)
            {
                int newRow = 0;
                for (int j = 0; j < column; j++)
                {
                    TransposeMatrix[newRow, newColumn] = matrix[i, j];
                    newRow++;
                }
                newColumn++;
            }
            return TransposeMatrix;
        }

        struct Matrix
        {
            public int row1;
            public int column1;
            public int row2;
            public int column2;


            public Matrix(int row1, int column1, int row2, int column2)
            {
                this.row1 = row1;
                this.column1 = column1;
                this.row2 = row2;
                this.column2 = column2;
            }

            public void PrintMatrix(int row, int column, int[,] matrix)
            {
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < column; j++)
                    {
                        Console.Write($"{matrix[i, j]}\t");
                    }
                    Console.WriteLine();
                }
            }

        }
    }

}
