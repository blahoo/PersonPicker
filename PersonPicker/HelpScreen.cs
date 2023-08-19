using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonPicker
{
    internal static class HelpScreen
    {
        public static void helpscreen()
        {
            Console.Clear();
            Title.smlTitle();
            controls();
            overview();
            instructions();
            credits();
            Console.WriteLine("   Press any key to continue... ");
            Console.ReadKey();
        }
        public static void controls()
        {
            Console.WriteLine("        Controls\n" +
                              "                   ,---,---,              ,-----,\n" +
                              "     [Move Up] =>  | W | E |  <= [Help]   |  <-'|\n" +
                              "                   ',--',--'               |    |\n" +
                              "    [Move Down] =>  | S |     [Select] =>  |    |\n" +
                              "                    '---'                  '----'\n");
        }
        public static void overview()
        {
            Console.WriteLine("        Overview\n" +
                              "   The purpose of this program is to randomly choose one\n" +
                              "  name out of however many you add. You can also edit and\n" +
                              "  remove certain names... it's pretty simple stuff.\n");
        }
        public static void instructions()
        {
            Console.WriteLine("        Basic Use\n" +
                              "  //=> Add a few names by selecting 'Add'\n" +
                              "  //=> Randomly pick a person by selcting 'Pick Person'\n");
        }
        public static void credits()
        {
            Console.WriteLine("  Credits: Nobody\n");
        }
    }
}
