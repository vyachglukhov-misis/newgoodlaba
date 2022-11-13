using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
namespace methods
{
    class Methods
    {
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
                    else
                    {
                        throw new Exception();
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
        public string CheckModeFirstTask(string[] lines)
        {
            if (lines.Length != 2)
            {
                return "incorrect .txt input file";
            }
            if (!(lines[0] == "a" || lines[0] == "b")){
                return "enter correct mode in first line of .txt file";
            }
            try
            {
                if (lines[1].GetType().GetElementType() == typeof(Int32))
                {
                    return "good";
                }
            }
            catch
            {
                return "incorect input line of nums in .txt file";
            }
            return "good";
        } 
        public int[] TryParseMatrixRow(string s, string prompt, int countOfColumns)
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
                    if (returnedNums.Length == countOfColumns)
                    {
                        flag = false;
                    }
                    else
                    {
                        throw new Exception();
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
        public string CheckStepMatrix__fl (string[] lines)
        {
            if (lines.Length < 2)
            {
                return "enter count of rows and at least one row";
            }
            int k = 0;
            try
            {
                for (; k < lines.Length; k++)
                {
                    lines[k].Split().Select(int.Parse).ToArray();
                }
            }
            catch
            {
                return $"not a number in row #{k + 1} ";
            }
            if (lines[0].Split(" ").Length != 1)
            {
                return "enter correct count of rows";
            }
            if (int.Parse(lines[0]) != lines.Length - 1)
            {
                return "first lane in .txt file shows how many rows in step matrix";
            }
            return "good";
            
        }
        public string CheckMatrices__fl(string[] lines)
        {
            int k = 0;
            try
            {
                for (; k< lines.Length; k++)
                {
                    lines[k].Split().Select(int.Parse).ToArray();
                } 
            }
            catch
            {
                return $"not a number in row #{k + 1} ";
            }
            int[] enteredSizeOfFirstMatrix = lines[0].Split().Select(int.Parse).ToArray();
            if (enteredSizeOfFirstMatrix.Length != 2)
            {
                return "incorrect size of first matrix";
            }
            int[] enteredSizeOfSecondMatrix = lines[1 + enteredSizeOfFirstMatrix[0]].Split().Select(int.Parse).ToArray();
            if (enteredSizeOfSecondMatrix.Length != 2)
            {
                return "incorrect size of second matrix";
            }
            if (enteredSizeOfFirstMatrix[0] + enteredSizeOfFirstMatrix[0] != lines.Length - 2)
            {
                return "count of rows of first matrix or count of rows of second matrix not equals their sizes. recorrect it in file";
            }
            for (int i = 0; i < enteredSizeOfFirstMatrix[0]; i++)
            {
                if (lines[1+i].Split(" ").Length != enteredSizeOfFirstMatrix[1])
                {
                    Console.WriteLine($"{lines[1 + i].Split(" ").Length}", enteredSizeOfFirstMatrix[1]);
                    return $"row #{i + 1} countains not {enteredSizeOfFirstMatrix[1]} columns in 1st matrix";
                }
            }
            for (int i = 0; i < enteredSizeOfFirstMatrix[0]; i++)
            {
                if (lines[enteredSizeOfFirstMatrix[0]+i + 2].Split(" ").Length != enteredSizeOfSecondMatrix[1])
                {
                    return $"row #{i+1} countains not {enteredSizeOfSecondMatrix[1]} columns in 2nd matrix";
                }
            }
            return "good";
        }
        public int[] TryParse(string s, string prompt)
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
                    flag = false;
                }
                catch
                {
                    Console.WriteLine(prompt);
                    s = Console.ReadLine();
                }
            } while (flag);
            return returnedNums;
        }
        public int[] QuickSort(int[] massive, int lI, int rI)
        {
            var i = lI;
            var j = rI;
            var pivot = massive[lI];

            while (i <= j)
            {
                while (massive[i] < pivot)
                {
                    i++;
                }
                while (massive[j] > pivot)
                {
                    j--;
                }
                if (i <= j)
                {
#pragma warning disable IDE0180 // Использовать кортеж для переключения значений
                    int temp = massive[i];
#pragma warning restore IDE0180 // Использовать кортеж для переключения значений
                    massive[i] = massive[j];
                    massive[j] = temp;
                    i++;
                    j--;
                }
            }
            if (lI < j)
            {
                QuickSort(massive, lI, j);
            }
            if (i < rI)
            {
                QuickSort(massive, i, rI);
            }
            return massive;
        }
        public MinMaxArray ArrayMinMax(int[] array)
        {
            int arrayMin = 999999999;
            int arrayMax = 0;
            int posOfMin = 0;
            int posOfMax = 0;
            for(int i = 0; i<array.Length; i++)
            {
                if (array[i] < arrayMin)
                {
                    arrayMin = array[i];
                    posOfMin = i;
                }
                if (array[i] > arrayMax)
                {
                    arrayMax = array[i];
                    posOfMax = i;
                }
            }
            return new MinMaxArray(posOfMin, arrayMin, arrayMax, posOfMax);
        }
        public void PrintEvenNumbers(int[] array)
        {
            
            for (int i=0; i< array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    Console.Write(array[i] + " ");
                }
            }
            Console.Write("\n");
        }
        public class MinMaxArray
        {
            public MinMaxArray() { }
            public MinMaxArray(int posOfMin, int min, int max, int posOfMax)
            {
                this.PosOfMin = posOfMin;
                this.Min = min;
                this.Max = max;
                this.PosOfMax = posOfMax;
            }
            public int PosOfMin { get; set; }
            public int Min { get; set; }

            public int Max { get; set; }
            public int PosOfMax { get; set; }
        }
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
        public int[][] SumMatrix(int[][] matrix1, int[][] matrix2)
        {
            int[][] summedMatrix = new int[matrix1.Length][];
            for (int i = 0; i < matrix1.Length; i++)
            {
                summedMatrix[i] = new int[matrix1[i].Length];
                for (int j = 0; j < matrix1[i].Length; j++)
                {
                    summedMatrix[i][j] = matrix1[i][j] + matrix2[i][j];
                }
            }
            return summedMatrix;
        }
        public int[][] SubstractionMatrix(int[][] matrix1, int[][] matrix2)
        {
            int[][] substractionMatrix = new int[matrix1.Length][];
            for (int i = 0; i < matrix1.Length; i++)
            {
                substractionMatrix[i] = new int[matrix1[i].Length];
                for (int j = 0; j < matrix1[i].Length; j++)
                {
                    substractionMatrix[i][j] = matrix1[i][j] - matrix2[i][j];
                }
            }


            return substractionMatrix;

        }
        public int[][] Multiply(int[][] matrix1, int[][] matrix2)
        {
            int[][] multipliedMatrix = new int[matrix1.Length][];

            for (int i = 0; i < matrix1.Length; i++)
            {
                multipliedMatrix[i] = new int[matrix2[i].Length];
                for (int j = 0; j < matrix2[i].Length; j++)
                {
                    for (int k = 0; k < matrix2.Length; k++)
                    {
                        multipliedMatrix[i][j] = multipliedMatrix[i][j] + matrix1[i][k] * matrix2[k][j];
                    }
                }
            }
            return multipliedMatrix;
        }
        public int[][] FillStepMatrixByRow(ref int[][] matrix, int countOfRows)
        {
            for (int i = 0; i < countOfRows; i++)
            {
                int[] enteredRow = TryParse(Console.ReadLine(), "enter the correct row of matrix");
                matrix[i] = new int[enteredRow.Length];

                for (int j = 0; j < enteredRow.Length; j++)
                {
                    matrix[i][j] = enteredRow[j];
                }
            }
            return matrix;
        }
        public int[][] FillMatrixByRow(ref int[][] matrix, int countOfRows, int countOfColumns)
        {
            for (int i = 0; i < countOfRows; i++)
            {
                int[] enteredRow = TryParseMatrixRow(Console.ReadLine(), "enter the correct row of matrix", countOfColumns);
                matrix[i] = new int[enteredRow.Length];

                for (int j = 0; j < enteredRow.Length; j++)
                {
                    matrix[i][j] = enteredRow[j];
                }
            }
            return matrix;
        }
        public int[][] FillMatrixByRow__fl(int[][] matrix, string[] rows)
        {
            for (int i= 0; i<matrix.Length; i++)
            {
                int[] splittedRow = rows[i].Split(" ").Select(int.Parse).ToArray();
                matrix[i] = new int[splittedRow.Length];
                for (int j = 0; j< splittedRow.Length; j++)
                {
                    matrix[i][j] = splittedRow[j];
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
        public int[][] ChangeMatrixItem(int[][] matrix, int row, int column, int item)
        {
            matrix[row][column] = item;
            return matrix;
        }
        public int[][] FillStepMatrixByRow__fl(int[][] matrix, string[] lines)
        {
            for (int i = 0; i<lines.Length-1; i++)
            {
                int[] row = lines[i+1].Split(" ").Select(int.Parse).ToArray();
                matrix[i] = new int[row.Length];
                for (int j = 0; j< row.Length; j++)
                {
                    matrix[i][j] = row[j];
                }
            }
            return matrix;
        }
        public int GetRandomInt()
        {
            Random GetRandomNum = new Random();
            int randomInt = GetRandomNum.Next();
            return randomInt;
        }
        public static MatrixInfo MatrixMaxMin(int[][] matrix)
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
    }
}