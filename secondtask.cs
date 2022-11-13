using System.Text.RegularExpressions;
using methods;
namespace task2
{
    public class TaskTwo {
        static Methods methods = new Methods();
        public class MatrixInfo
        {
            public MatrixInfo() { }
            public MatrixInfo(int[] posOfMin, int min, int max, int[] posOfMax)
            {
                this.PosOfMin = posOfMin;
                this.Min = min;
                this.Max = max;
                this.PosOfMax = posOfMax;
            }
            public int[] PosOfMin { get; set; }
            public int Min { get; set; }

            public int Max { get; set; }
            public int[] PosOfMax { get; set; }
        }
        public static int[][] SumMatrix(int[][] matrix1, int[][] matrix2)
        {
            int[][] summedMatrix = new int[matrix1.Length][];
            for(int i=0; i<matrix1.Length; i++)
            {
                summedMatrix[i] = new int[matrix1[i].Length];
                for(int j=0; j < matrix1[i].Length; j++)
                {
                    summedMatrix[i][j] = matrix1[i][j] + matrix2[i][j];
                }
            }
            return summedMatrix;
        }

        public static int[][] SubstractionMatrix(int[][] matrix1, int[][] matrix2)
        {
            int[][] substractionMatrix = new int[matrix1.Length][];
            for (int i=0; i < matrix1.Length; i++)
            {
                substractionMatrix[i] = new int[matrix1[i].Length];
                for (int j =0; j<matrix1[i].Length; j++)
                {
                    substractionMatrix[i][j] = matrix1[i][j] - matrix2[i][j];
                }    
            }


            return substractionMatrix;

        }
        public static int[][] Multiply(int[][] matrix1, int[][] matrix2)
        {
                int[][] multipliedMatrix = new int[matrix1.Length][];

                for(int i=0; i<matrix1.Length; i++)
                {
                multipliedMatrix[i] = new int[matrix2[i].Length];
                    for (int j = 0; j < matrix2[i].Length; j++)
                    {
                        for(int k = 0; k < matrix2.Length; k++)
                        {
                            multipliedMatrix[i][j] = multipliedMatrix[i][j] + matrix1[i][k] * matrix2[k][j];
                        }
                    }
                }
                return multipliedMatrix;
        }
    public static int[][] FillMatrixByRow(ref int[][] matrix, int countOfRows)
        {
            for (int i = 0; i < countOfRows; i++)
            {
                int[] enteredRow = methods.TryParse(Console.ReadLine(), $"enter the correct {i+1} row of matrix");
                matrix[i] = new int[enteredRow.Length];

                for (int j = 0; j < enteredRow.Length; j++)
                {
                    matrix[i][j] = enteredRow[j];
                }
            }
            return matrix;
        }

        public void OutputStepMatrix(int[][] matrix)
            {
                for (int i = 0; i < matrix.Length; i++)
                {
                    for (int j = 0; j < matrix[i].Length; j++)
                    {
                        Console.Write("{0}\t", matrix[i][j]);
                    }
                    Console.WriteLine();
                }
            }
        static MatrixInfo MatrixMaxMin(int[][] matrix)
        {
            int matrixMin = 999999999;
            int matrixMax = 0;
            int[] posOfMin = { 0, 0 };
            int[] posOfMax = { 0, 0 };
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrixMin > matrix[i][j])
                    {
                        matrixMin = matrix[i][j];
                        posOfMin[0] = i;
                        posOfMin[1] = j;
                    }
                    if (matrixMax < matrix[i][j])
                    {
                        matrixMax = matrix[i][j];
                        posOfMax[0] = i;
                        posOfMax[1] = j;
                    }
                }
            }
            return new MatrixInfo(posOfMin, matrixMin, matrixMax, posOfMax);
        }
        public static int[] StringToMassive(string s)
        {

            return Regex.Replace(Regex.Replace(s, "[a-zA-Z]", " "), "[ ]+", " ")
                    .Trim()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
        }

        public void secondTask()
        {
            Console.WriteLine("enter the size of first matrix");
            int[] enteredSizeOfMatrix = methods.TryParseMatrixSize(Console.ReadLine(), "enter the correct size of matrix");
            Console.WriteLine($"enter {enteredSizeOfMatrix[0]} rows (lines) of first matrix");
            int[][] matrix1 = new int[enteredSizeOfMatrix[0]][];
            matrix1 = methods.FillMatrixByRow(ref matrix1, enteredSizeOfMatrix[0], enteredSizeOfMatrix[1]);
            methods.OutputStepMatrix(matrix1);


            Console.WriteLine($"Max: {MatrixMaxMin(matrix1).Max}, row: {MatrixMaxMin(matrix1).PosOfMax[0] + 1}, column: {MatrixMaxMin(matrix1).PosOfMax[1] + 1}");
            Console.WriteLine($"Min: {MatrixMaxMin(matrix1).Min}, row:{MatrixMaxMin(matrix1).PosOfMin[0] + 1}, column: {MatrixMaxMin(matrix1).PosOfMin[1] + 1}");

            Console.WriteLine("enter the size of second matrix");
            enteredSizeOfMatrix = methods.TryParseMatrixSize(Console.ReadLine(), "enter the correct size of matrix");
            int[][] matrix2 = new int[enteredSizeOfMatrix[0]][];
            matrix2 = methods.FillMatrixByRow(ref matrix2, enteredSizeOfMatrix[0], enteredSizeOfMatrix[1]);
            if (matrix1[0].Length == matrix2.Length)
            {
                Console.WriteLine("Multiplication:");
                methods.OutputStepMatrix(methods.Multiply(matrix1, matrix2));
            }
            else
            {
                Console.WriteLine("Multiplication operation is not available");
            }
            if (matrix1.Length == matrix2.Length && matrix1[0].Length == matrix2[0].Length){
                Console.WriteLine("Addiction:");
                methods.OutputStepMatrix(methods.SumMatrix(matrix1, matrix2));
                Console.WriteLine("Substruction:");
                methods.OutputStepMatrix(methods.SubstractionMatrix(matrix1, matrix2));
            }else
            {
                Console.WriteLine("Substraction operation is not available");
                Console.WriteLine("Addiction operation is not available");

            }
        }
    }
}