using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonPicker
{
    internal static class Data
    {
        public static List<string> entries = new List<string>();
        public static Random rnd = new Random();
        
        public static int count()
        {
            return entries.Count;
        }
        public static string choose()
        {
            return entries[rnd.Next(0, entries.Count)];
        }
        public static void add(string name)
        {            
            entries.Add(name);
        }
        public static void edit(int index, string name)
        {
            entries.Insert(index, name);
            entries.RemoveAt(index+1);
        }     
        public static void remove(int index)
        {
            entries.RemoveAt(index);
        }
        public static void clear()
        {
            entries.Clear();
        }
    }
}
