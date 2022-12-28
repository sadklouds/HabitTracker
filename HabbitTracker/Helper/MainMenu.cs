using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace HabitTracker.Helper
{
    public static class MainMenu
    {
        public static void DisplayMenu()
        {
            Console.WriteLine("MAIN MENU");
            Console.WriteLine("--------------------");
            Console.WriteLine("Track the amount of water drunken");
            Console.WriteLine("--------------------");
            Console.WriteLine("1: View All Records.");
            Console.WriteLine("2: Insert Records.");
            Console.WriteLine("3: Delete Record");
            Console.WriteLine("4: Update Record");
            Console.WriteLine("0: Exit Program");
            Console.WriteLine("--------------------");
        }
    }
}
