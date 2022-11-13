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
        public void doTask1()
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
    }
}
    
