using System.Data;
using System.Text.RegularExpressions;
using methods;
namespace task3
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


    public class TaskThree
    {
        Methods methods = new Methods();
        public static void RunThirdTask(string mode, TaskThree taskThree) {
            taskThree.thirdTask(mode);
        }



        public void thirdTask(string mode)
        {
            if (mode == "kb")
            {
                Console.WriteLine("enter the count of rows");
                int countOfRows = int.Parse(Console.ReadLine());
                int[][] stepMatrix = new int[countOfRows][];
                stepMatrix = methods.FillStepMatrixByRow(ref stepMatrix, countOfRows);

                methods.OutputStepMatrix(stepMatrix);
                Console.WriteLine($"Max: {Methods.MatrixMaxMin(stepMatrix).Max}, row: {Methods.MatrixMaxMin(stepMatrix).PosOfMax[0] + 1}, column: {Methods.MatrixMaxMin(stepMatrix).PosOfMax[1] + 1}");
                Console.WriteLine($"Min: {Methods.MatrixMaxMin(stepMatrix).Min}, row:{Methods.MatrixMaxMin(stepMatrix).PosOfMin[0] + 1}, column: {Methods.MatrixMaxMin(stepMatrix).PosOfMin[1] + 1}");


                Console.WriteLine("enter the index of item[row][column] you want to change");
                int[] posOfItem = methods.TryParse(Console.ReadLine(), "enter the correct ");
                stepMatrix = methods.ChangeMatrixItem(stepMatrix, posOfItem[0], posOfItem[1], methods.GetRandomInt());
                methods.OutputStepMatrix(stepMatrix);
            }
            else
            {
                string filepath = String.Join("\\", ((AppDomain.CurrentDomain.BaseDirectory).Split("\\").SkipLast(4).ToArray())) + "\\input.txt";
                string[] lines = File.ReadAllLines(@filepath);
                if (methods.CheckStepMatrix__fl(lines) == "good")
                {
                    int[][] stepMatrix = new int[int.Parse(lines[0])][];
                    stepMatrix = methods.FillStepMatrixByRow__fl(stepMatrix, lines);
                    Console.WriteLine("Step Matrix:");
                    methods.OutputStepMatrix(stepMatrix);
                    Console.WriteLine($"Max: {Methods.MatrixMaxMin(stepMatrix).Max}, row: {Methods.MatrixMaxMin(stepMatrix).PosOfMax[0] + 1}, column: {Methods.MatrixMaxMin(stepMatrix).PosOfMax[1] + 1}");
                    Console.WriteLine($"Min: {Methods.MatrixMaxMin(stepMatrix).Min}, row:{Methods.MatrixMaxMin(stepMatrix).PosOfMin[0] + 1}, column: {Methods.MatrixMaxMin(stepMatrix).PosOfMin[1] + 1}");


                    Console.WriteLine("enter the index of item[row][column] you want to change");
                    int[] posOfItem = methods.TryParse(Console.ReadLine(), "enter the correct ");
                    stepMatrix = methods.ChangeMatrixItem(stepMatrix, posOfItem[0], posOfItem[1], methods.GetRandomInt());
                    methods.OutputStepMatrix(stepMatrix);
                }
                else
                {
                    Console.WriteLine(methods.CheckStepMatrix__fl(lines));
                }
            }
        }
    }
}