using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PersonPicker
{
    internal static class Title
    {
        public static string startMsg = "                                    Press 'enter' To Start !";
        
        public static string exitMsg = "                                   Press Any Key To Continue...";
        
        public static void title()
        {
            Console.WriteLine("\n  ██████╗░███████╗██████╗░░██████╗░█████╗░███╗░░██╗  ██████╗░██╗░█████╗░██╗░░██╗███████╗██████╗░\n" +
                                "  ██╔══██╗██╔════╝██╔══██╗██╔════╝██╔══██╗████╗░██║  ██╔══██╗██║██╔══██╗██║░██╔╝██╔════╝██╔══██╗\n" +
                                "  ██████╔╝█████╗░░██████╔╝╚█████╗░██║░░██║██╔██╗██║  ██████╔╝██║██║░░╚═╝█████═╝░█████╗░░██████╔╝\n" +
                                "  ██╔═══╝░██╔══╝░░██╔══██╗░╚═══██╗██║░░██║██║╚████║  ██╔═══╝░██║██║░░██╗██╔═██╗░██╔══╝░░██╔══██╗\n" +
                                "  ██║░░░░░███████╗██║░░██║██████╔╝╚█████╔╝██║░╚███║  ██║░░░░░██║╚█████╔╝██║░╚██╗███████╗██║░░██║\n" +
                                "  ╚═╝░░░░░╚══════╝╚═╝░░╚═╝╚═════╝░░╚════╝░╚═╝░░╚══╝  ╚═╝░░░░░╚═╝░╚════╝░╚═╝░░╚═╝╚══════╝╚═╝░░╚═╝\n");           
        }
        public static void smlTitle()
        {
            Console.WriteLine("\n  █▀█ █▀▀ █▀█ █▀ █▀█ █▄ █   █▀█ █ █▀▀ █▄▀ █▀▀ █▀█\n" +
                                "  █▀▀ ██▄ █▀▄ ▄█ █▄█ █ ▀█   █▀▀ █ █▄▄ █ █ ██▄ █▀▄\n\n");
        }
        public static void subTitle()
        {
            Console.WriteLine($"  PERSON PICKER (max: {MainScreen.limit})");
        }
    }
}
