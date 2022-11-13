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
    }

}