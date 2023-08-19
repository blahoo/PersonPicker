using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PersonPicker
{
    internal class Program
    {
        
        static void check(out bool idle)
        {
            idle = true;
            if (Console.KeyAvailable)
            {
                if (Console.ReadKey().Key == ConsoleKey.Enter)
                {
                    idle = false;
                }
            }
            else
            {
                idle = true;
            }
        }
        static void StartScreen()
        {
            Title.title();
            Console.WriteLine(Title.startMsg);
            bool idle = true;
            while (idle)
            {
                check(out idle);
            }
        }
        static void TutScreen()
        {
            Console.Clear();
            Title.smlTitle();
            HelpScreen.controls();
            Console.WriteLine("     Press any key to continue... ");
            Console.ReadKey();
        }
        static void Main(string[] args)
        {
            Console.Title = "Person Picker";
            Console.CursorVisible = false;
            StartScreen();
            TutScreen();
            MainScreen.menu();
        }
    }
}
