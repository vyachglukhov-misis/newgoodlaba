using System.Data;
using System.Text.RegularExpressions;
namespace laba2
{

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


    public class Program_Task2
    {
        public static int[] StringToMassive(string s)
        {

            return Regex.Replace(Regex.Replace(s, "[a-zA-Z]", " "), "[ ]+", " ")
                    .Trim()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
        }

        public static int GetRandomInt()
        {
            Random GetRandomNum = new Random();
            int randomInt = GetRandomNum.Next();
            return randomInt;
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
        public int[] TryParseMatrixSize(string s, string prompt)
        {
            bool flag = true;
            int[] returnedNums = new int[0];
            do
            {
                try
                {
                    returnedNums = Regex.Replace(Regex.Replace(s, "[a-zA-Z]", " "), "[ ]+", " ")
                    .Trim()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                    if (returnedNums.Length == 2)
                    {
                        flag = false;
                    }
                }
                catch
                {
                    Console.WriteLine(prompt);
                    s = Console.ReadLine();
                }
            } while (flag);
            return returnedNums;
        }


        public static void OutputStepMatrix(int[][] matrix)
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
        public static int[][] ChangeMatrixItem(int[][] matrix, int row, int column, int item)
        {
            matrix[row][column] = item;
            return matrix;
        }

        public static int[][] FillStepMatrixByRow(ref int[][] matrix, int countOfRows)
        {
            for (int i = 0; i < countOfRows; i++)
            {
                int[] enteredRow = StringToMassive(Console.ReadLine());
                matrix[i] = new int[enteredRow.Length];

                for (int j = 0; j < enteredRow.Length; j++)
                {
                    matrix[i][j] = enteredRow[j];
                }
            }
            return matrix;
        }

        public static void asd()
        {
            int countOfRows = int.Parse(Console.ReadLine());
            int[][] stepMatrix = new int[countOfRows][];
            stepMatrix = FillStepMatrixByRow(ref stepMatrix, countOfRows);

            OutputStepMatrix(stepMatrix);
            Console.WriteLine($"Max: {MatrixMaxMin(stepMatrix).Max}, row: {MatrixMaxMin(stepMatrix).PosOfMax[0]+1}, column: {MatrixMaxMin(stepMatrix).PosOfMax[1]+1}");
            Console.WriteLine($"Min: {MatrixMaxMin(stepMatrix).Min}, row:{MatrixMaxMin(stepMatrix).PosOfMin[0]+1}, column: {MatrixMaxMin(stepMatrix).PosOfMin[1]+1}");


            Console.WriteLine("enter the row and the column of item you want to change");
            int[] posOfItem = StringToMassive(Console.ReadLine());
            stepMatrix = ChangeMatrixItem(stepMatrix, posOfItem[0], posOfItem[1], GetRandomInt());
            OutputStepMatrix(stepMatrix);
        }
    }
}