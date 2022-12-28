using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabitTracker.Helper
{
    public static class CommonMessages
    {
        public static void EmptyTable()
        {
            Console.WriteLine("\nData base table contains not data.");
        }
        public static void IncorrectDate()
        {
            Console.WriteLine("\nIncorrect Format given, correct format is (DD/MM/YYYY))");
        }
        public static void NumberNotGiven()
        {
            Console.WriteLine("\nIncorrect data given, please enter a number.");
        }
        public static void IncorrectNumeric()
        {
            Console.WriteLine("Please enter a none decimal number for habit ID");
        }
    }
}
