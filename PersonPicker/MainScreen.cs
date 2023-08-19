using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PersonPicker
{
    internal static class MainScreen
    {
        public static string[] opt = { " << Pick Person >>\n", " << Add >>", " << Edit >>", " << Remove >>", " << Clear >>", " << Exit >>" };
        
        public static int choice = 1;

        public static int limit = 10;

        public static void display()
        {
            Console.WriteLine("____________________________");
            for (int i = 0; i < Data.count(); i++)
            {
                string s;
                if (i < 9)
                {
                    s = "0";
                }
                else
                {
                    s = "";
                }
                Console.WriteLine($"{s}{i+1}| {Data.entries[i]}");
            }
            Console.WriteLine("__|_________________________\n");
        }
        public static void options(int choice)
        {            
            for (int i = 0; i < opt.Length; i++)
            {
                if ((!(i == 1 || i == 5) && Data.count() == 0)||(i == 1 && Data.count() == limit))
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine($"  {opt[i]}");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    if (i == choice)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine($" *{opt[i]}");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else
                    {
                        Console.WriteLine($"  {opt[i]}");
                    }
                }
            }
            Console.WriteLine("\n Press 'E' for help\n____________________________");
        }
        public static void update()
        {
            Console.Clear();
            if (Data.count() == 0 && !(choice == 1 || choice == 5))
            {
                choice = 1;
            }else if (Data.count() == limit && choice == 1)
            {
                choice = 0;
            }
            Title.subTitle();
            display();
            options(choice);
        }
        public static void menu()
        {
            bool cont = true;
            update();

            while (cont)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.W && choice > 0) // W pressed -----------------------                      
                {
                    if (Data.count() == 0)
                    {
                        if (choice == 5) { choice = 1; update(); }   
                    }
                    else if (Data.count() == limit && choice == 2)
                    {
                        choice -= 2;
                        update();
                    }
                    else
                    {               
                        choice--;
                        update();
                    }
                }
                else if (key.Key == ConsoleKey.S && choice < opt.Length-1) // S pressed -------          
                {
                    if (Data.count() == 0)
                    {
                        if (choice == 1) { choice = 5; update(); }
                    }
                    else if (Data.count() == limit && choice == 0)
                    {
                        choice += 2;
                        update();
                    }
                    else
                    {
                        choice++;
                        update();
                    }
                }
                else if (key.Key == ConsoleKey.E) // E pressed --------------------------------
                {
                    HelpScreen.helpscreen();
                    update();
                }
                else if (key.Key == ConsoleKey.Enter)
                {
                    Console.CursorVisible = true;
                    bool reTry;
                    switch (choice)
                    {
                        case 0: //pick person -------------------------------------------------
                            if (Data.count() > 0)
                            {
                                string chosen = Data.choose();
                                Console.WriteLine($"\n   Person Picked: {chosen}");
                                Console.Write("\n => Remove name? (y/n): ");
                                do 
                                {
                                    ConsoleKey tkey = Console.ReadKey(true).Key;
                                    if (tkey == ConsoleKey.Y)
                                    {
                                        Data.entries.Remove(chosen);
                                        Console.Write(tkey.ToString().ToLower());
                                        break;
                                    }
                                    if (tkey == ConsoleKey.N)
                                    {
                                        Console.Write(tkey.ToString().ToLower());
                                        break;
                                    }
                                } while (true);
                                Console.Write("\n Press any key to continue... ");
                                Console.ReadKey(true);
                            }
                            break;
                        case 1: //add name ----------------------------------------------------       
                            if (Data.count() < limit)
                            {
                                Console.WriteLine("\n *Enter nothing to skip* ");
                                Console.Write(" => Enter name: ");
                                string name = Console.ReadLine().Trim();
                                if (name == "") { break; }    
                                Data.add(name);  
                            }
                            break;
                        case 2: //edit name ---------------------------------------------------                              
                            do
                            {
                                Console.WriteLine("\n *Enter nothing to skip* ");
                                Console.Write(" => Enter index to edit: ");
                                string index = Console.ReadLine().Trim();
                                if (index == "") { break; }
                                if (int.TryParse(index, out var value) && value-1 < Data.count() && value-1 >= 0)
                                {
                                    Console.WriteLine("\n *Enter nothing to skip* ");
                                    Console.Write(" => Enter new name: ");
                                    string name = Console.ReadLine().Trim();
                                    if (name == "") { break; }
                                    Data.edit(value-1, name);                                    
                                    reTry = false;
                                }
                                else
                                {
                                    Console.WriteLine("   Invalid!");
                                    reTry = true;
                                }
                            } while (reTry);
                            break;
                        case 3: //remove name -------------------------------------------------
                            do
                            {
                                Console.WriteLine("\n *Enter nothing to skip* ");
                                Console.Write(" => Enter index to remove: ");
                                string index = Console.ReadLine().Trim();
                                if (index == "") { break; }
                                if (int.TryParse(index, out var value) && value-1 < Data.count() && value-1 >= 0)
                                {
                                    Data.remove(value-1);                                
                                    reTry = false;
                                }
                                else
                                {
                                    Console.WriteLine("   Invalid!");
                                    reTry = true;
                                }
                            }while (reTry);
                            break;
                        case 4: //clear -------------------------------------------------------
                            Console.Write("\n => Clear Names? (y/n): ");
                            do
                            {
                                ConsoleKey tkey = Console.ReadKey(true).Key;
                                if (tkey == ConsoleKey.Y)
                                {
                                    Console.Write(tkey.ToString().ToLower());
                                    Data.clear();
                                    break;
                                }
                                if (tkey == ConsoleKey.N)
                                {
                                    Console.Write(tkey.ToString().ToLower());
                                    break;
                                }
                                Data.clear();
                            }while (true);
                            break;
                        case 5: //exit --------------------------------------------------------
                            cont = false;
                            break;
                    }
                    Console.CursorVisible = false;
                    if (cont)
                    {
                        update();
                    }
                    else 
                    {
                        Console.Clear();
                        Title.title();
                        Console.WriteLine(Title.exitMsg);
                        Console.ReadKey(); 
                    }
                }
            }   
        }
    }
}
