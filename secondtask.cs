using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using methods;
using static System.Net.Mime.MediaTypeNames;

namespace task2
{
    public class TaskTwo {
        static Methods methods = new Methods();

        public async void secondTask(string mode)
        {
            if (mode == "kb")
            {
                Console.WriteLine("enter the size of first matrix");
                int[] enteredSizeOfMatrix = methods.TryParseMatrixSize(Console.ReadLine(), "enter the correct size of matrix");
                Console.WriteLine($"enter {enteredSizeOfMatrix[0]} rows (lines) of first matrix");
                int[][] matrix1 = new int[enteredSizeOfMatrix[0]][];
                matrix1 = methods.FillMatrixByRow(ref matrix1, enteredSizeOfMatrix[0], enteredSizeOfMatrix[1]);
                methods.OutputStepMatrix(matrix1);


                Console.WriteLine($"Max: {Methods.MatrixMaxMin(matrix1).Max}, row: {Methods.MatrixMaxMin(matrix1).PosOfMax[0] + 1}, column: {Methods.MatrixMaxMin(matrix1).PosOfMax[1] + 1}");
                Console.WriteLine($"Min: {Methods.MatrixMaxMin(matrix1).Min}, row:{Methods.MatrixMaxMin(matrix1).PosOfMin[0] + 1}, column: {Methods.MatrixMaxMin(matrix1).PosOfMin[1] + 1}");

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
                if (matrix1.Length == matrix2.Length && matrix1[0].Length == matrix2[0].Length)
                {
                    Console.WriteLine("Addiction:");
                    methods.OutputStepMatrix(methods.SumMatrix(matrix1, matrix2));
                    Console.WriteLine("Substruction:");
                    methods.OutputStepMatrix(methods.SubstractionMatrix(matrix1, matrix2));
                }
                else
                {
                    Console.WriteLine("Substraction operation is not available");
                    Console.WriteLine("Addiction operation is not available");

                }
            }
            else
            {
                string filepath = String.Join("\\", ((AppDomain.CurrentDomain.BaseDirectory).Split("\\").SkipLast(4).ToArray())) + "\\input.txt";
                string[] lines = File.ReadAllLines(@filepath);
                if (methods.CheckMatrices__fl(lines) == "good")
                {
                    int[] enteredSizeOfFirstMatrix = lines[0].Split(" ").Select(int.Parse).ToArray();
                    int[][] matrix1 = new int[enteredSizeOfFirstMatrix[0]][];
                    Range range = 1..(1+enteredSizeOfFirstMatrix[0]);
                    matrix1 = methods.FillMatrixByRow__fl(matrix1, lines[range]);
                    Console.WriteLine("1st matrix:");
                    methods.OutputStepMatrix(matrix1);


                    int[] enteredSizeOfSecondMatrix = lines[1+enteredSizeOfFirstMatrix[0]].Split(" ").Select(int.Parse).ToArray();
                    int[][] matrix2 = new int[enteredSizeOfSecondMatrix[0]][];
                    range = (2 + enteredSizeOfFirstMatrix[0])..(lines.Length);
                    matrix2 = methods.FillMatrixByRow__fl(matrix1, lines[range]);
                    if (matrix1[0].Length == matrix2.Length)
                    {
                        Console.WriteLine("Multiplication:");
                        methods.OutputStepMatrix(methods.Multiply(matrix1, matrix2));
                    }
                    else
                    {
                        Console.WriteLine("Multiplication operation is not available");
                    }
                    if (matrix1.Length == matrix2.Length && matrix1[0].Length == matrix2[0].Length)
                    {
                        Console.WriteLine("Addiction:");
                        methods.OutputStepMatrix(methods.SumMatrix(matrix1, matrix2));
                        Console.WriteLine("Substruction:");
                        methods.OutputStepMatrix(methods.SubstractionMatrix(matrix1, matrix2));
                    }
                    else
                    {
                        Console.WriteLine("Substraction operation is not available");
                        Console.WriteLine("Addiction operation is not available");

                    }
                }
                else
                {
                    Console.WriteLine(methods.CheckMatrices__fl(lines));
                }
            }
        }
    }
}