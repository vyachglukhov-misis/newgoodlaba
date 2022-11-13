using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using methods;
namespace taskOne
{
    class TaskOne
    {
        static Methods methods = new Methods();
        public static void Bmode()
        {
            Console.WriteLine("enter the line of nums");
            int[] enteredNums = methods.TryParse(Console.ReadLine(), "enter the correct line of nums");
            Console.WriteLine(String.Join(" ", enteredNums));
            Methods.MinMaxArray arrayInfo = methods.ArrayMinMax(enteredNums);
            Console.WriteLine($"Min: {arrayInfo.Min}, Max: {arrayInfo.Max}");
            Console.WriteLine($"{arrayInfo.PosOfMax} {arrayInfo.PosOfMin}");
            Console.WriteLine(String.Join(" ", methods.QuickSort(enteredNums, 0, enteredNums.Length - 1)));
            Array.Reverse(enteredNums);
            Console.WriteLine(String.Join(" ", enteredNums));
            methods.PrintEvenNumbers(enteredNums);
        }
        public static void Amode()
        {
            Console.WriteLine("enter the line of nums");
            int[] enteredNums = methods.TryParse(Console.ReadLine(), "enter the correct line of nums");
            Console.WriteLine(String.Join(" ", enteredNums));
            Methods.MinMaxArray arrayInfo = methods.ArrayMinMax(enteredNums);
            Console.WriteLine($"Min: {arrayInfo.Min}, Max: {arrayInfo.Max}");
            Console.WriteLine($"{arrayInfo.PosOfMax} {arrayInfo.PosOfMin}");
            int[] sortedArray = new int[enteredNums.Length];
            enteredNums.CopyTo(sortedArray, 0);
            Array.Sort(sortedArray);
            Console.WriteLine(String.Join(" ", sortedArray));
            Array.Reverse(sortedArray);
            Console.WriteLine(String.Join(" ", sortedArray));
            methods.PrintEvenNumbers(sortedArray);
        }
        public static void Amode__fl(string[] lines)
        {
            int[] inputNums = lines[1].Split(" ").Select(int.Parse).ToArray();
            Console.WriteLine(String.Join(" ", inputNums));
            Methods.MinMaxArray arrayInfo = methods.ArrayMinMax(inputNums);
            Console.WriteLine($"Min: {arrayInfo.Min}, Max: {arrayInfo.Max}");
            Console.WriteLine($"{arrayInfo.PosOfMax} {arrayInfo.PosOfMin}");
            int[] sortedArray = new int[inputNums.Length];
            inputNums.CopyTo(sortedArray, 0);
            Array.Sort(sortedArray);
            Console.WriteLine(String.Join(" ", sortedArray));
            Array.Reverse(sortedArray);
            Console.WriteLine(String.Join(" ", sortedArray));
            methods.PrintEvenNumbers(sortedArray);
        }
        public static void Bmode__fl(string[] lines)
        {
            int[] inputNums = lines[1].Split(" ").Select(int.Parse).ToArray();
            Console.WriteLine(String.Join(" ", inputNums));
            Methods.MinMaxArray arrayInfo = methods.ArrayMinMax(inputNums);
            Console.WriteLine($"Min: {arrayInfo.Min}, Max: {arrayInfo.Max}");
            Console.WriteLine($"{arrayInfo.PosOfMax} {arrayInfo.PosOfMin}");
            Console.WriteLine(String.Join(" ", methods.QuickSort(inputNums, 0, inputNums.Length - 1)));
            Array.Reverse(inputNums);
            Console.WriteLine(String.Join(" ", inputNums));
            methods.PrintEvenNumbers(inputNums);
        }
        public void doTask1(string wtf)
        {
            if (wtf == "kb")
            {

                Console.WriteLine("enter the mode you want to use (a or b)");
                string mode = Console.ReadLine();
                while (!((mode != "a" && mode == "b") || (mode != "b" && mode == "a")))
                {
                    Console.WriteLine("enter the correct mode (a or b)");
                    mode = Console.ReadLine();
                }

                if (mode == "a")
                {
                    Amode();
                }
                if (mode == "b")
                {
                    Bmode();
                }
            }
            else
            {
                string filepath = String.Join("\\", ((AppDomain.CurrentDomain.BaseDirectory).Split("\\").SkipLast(4).ToArray())) + "\\input.txt";
                string[] lines = File.ReadAllLines(@filepath);
                if (methods.CheckModeFirstTask(lines) == "good")
                {
                    if (lines[0] == "a")
                    {
                        Amode__fl(lines);
                    }
                    if (lines[0] == "b")
                    {
                        Bmode__fl(lines);
                    }
                }
                else
                {
                    Console.WriteLine(methods.CheckModeFirstTask(lines));
                }
            }
        }
    }
}
    
