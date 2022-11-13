using KeyboardMenu;
using System.Diagnostics;
using taskOne;
using task2;
namespace MainProgram
{
    class MainProgram
    {
        static TaskTwo task2 = new TaskTwo();
        static TaskOne task1 = new TaskOne();
        public static void StartMainMenu()
        {
            string prompt = "Lab #1 by Vyach GLukhov. MISIS 2022";
            string[] options = { "task 1", "task 2", "task 3", "exit"};
            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.Run();
            switch (selectedIndex)
            {
                case 0:
                    RunFirstTask();
                    break;
                case 1:
                    RunSecondTask();
                    break;
                case 2:
                    Console.WriteLine(2);
                    break;
                case 3:
                    Exit();
                    break;
            }
        }
        static private void RunFirstTask()
        {
            Console.Clear();
            task1.doTask1();
            Console.WriteLine("Press any key to return for main menu");
            Console.ReadKey(true);
            StartMainMenu();
        }
        static private void RunSecondTask()
        {
            Console.Clear();
            task2.secondTask();
            Console.WriteLine("Press any key to return for main menu");
            Console.ReadKey(true);
            StartMainMenu();
        }
        static private void Exit()
        {
            Environment.Exit(0);
        }
        public static void Main(string[] args)
        {
            StartMainMenu();
        }
    }
}