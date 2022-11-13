using KeyboardMenu;
using System.Diagnostics;
using taskOne;
using task2;
using System.Data;
using task3;

namespace MainProgram
{
    class MainProgram
    {
        static TaskTwo task2 = new TaskTwo();
        static TaskOne task1 = new TaskOne();
        static TaskThree task3 = new TaskThree();
        static string mode = "kb";
        public static void StartMainMenu()
        {
            string prompt = "Lab #1 by Vyach Glukhov. MISIS 2022";
            string[] options = { "task 1", "task 2", "task 3", $"change mode. current mode: {MainProgram.mode}", "exit" };
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
                        RunThirdTask();
                        break;
                    case 3:
                        ChangeMode();
                        break;
                    case 4:
                        Exit();
                        break;
                }
        }
        static private void RunFirstTask()
        {
            Console.Clear();
            task1.doTask1(MainProgram.mode);
            Console.WriteLine("Press any key to return for main menu");
            Console.ReadKey(true);
            StartMainMenu();
        }
        static private void RunSecondTask()
        {
            Console.Clear();
            task2.secondTask(MainProgram.mode);
            Console.WriteLine("Press any key to return for main menu");
            Console.ReadKey(true);
            StartMainMenu();
        }
        static private void RunThirdTask()
        {
            Console.Clear();
            task3.thirdTask(MainProgram.mode);
            Console.WriteLine("Press any key to return for main menu");
            Console.ReadKey(true);
            StartMainMenu();
        }
        static private void ChangeMode()
        {
            if (MainProgram.mode == "kb")
            {
                MainProgram.mode = "fl";
            } else
            {
                MainProgram.mode = "kb";
            }
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