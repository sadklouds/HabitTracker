using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using HabitTracker.Models;
using HabitTracker.Helper;

namespace HabitTracker
{
    public class HabitTrackerLogic
    {
       
        IDataAccess db = new SqliteDataAccess();

        public void Run()
        {
           db.ConnectDB();
           GetOperations();
        }

        public void GetOperations()
        {
            MainMenu.DisplayMenu();
            int Operation;
            while (true)
            {
                Console.Write("Which operation do you wish to perform?: ");
                string input = Console.ReadLine();

                if (Int32.TryParse(input, out Operation))
                {
                    switch (Operation)
                    {
                        case 1:
                            GetData();
                            break;
                        case 2:
                            AddHabit();
                            break;
                        case 3:
                            DeleteHabit();
                            break;
                        case 4:
                            UpdateHabit();
                            break;
                        
                        case 0:
                            Console.WriteLine("Exiting Habit Tracker...");
                            return;
                        default:
                            Console.WriteLine("Unknown command was given.");
                            break;
                    }
                }

               else Console.WriteLine("Aa none decimal number was not given!");
            }
            
        }
        // ensures date follows correct formatting
        public DateTime DateValidator()
        {
            while (true)
            {
                Console.Write("\nEnter Date of habit (DD-MM-YYYY): ");
                string input = Console.ReadLine();
                DateTime date;
            
                if (DateTime.TryParseExact(input, "dd/mm/yyyy", new CultureInfo("en-GB"), DateTimeStyles.None, out date))
                {
                    return date;
                }
                else
                {
                    CommonMessages.IncorrectDate();
                    continue;
                }
            }
        }
        //Makes sure valid number is resturned.
        public float QuantityValidator()
        {
            Console.Write("Enter quantity of habit (number): ");
            string input = Console.ReadLine();
            float quantity;
            while (true)
            {
                if (Single.TryParse(input, out quantity)) return quantity;
                else
                {
                    CommonMessages.NumberNotGiven();
                }
            }
        }

        // Crud operations to add/delete,update and view database data

        public void AddHabit()
        {
            string date = DateValidator().ToString();
            string title = GetHabitTitle();
            float quantity = QuantityValidator();
            string unit = GetUnitMeasure();
            db.InsertData(date, title, quantity, unit);
        }

        public string GetHabitTitle()
        {
            Console.Write("Enter title of habit (Ran for, Number of glasses of water drank etc): ");
            string ?input = Console.ReadLine();
            if (input == null)
            {
                return GetHabitTitle();
            }
            return input;
        }

        public string GetUnitMeasure()
        {
            Console.Write("Enter unit measure (KM,MM,L) leave empty if none fit: ");
            string? input = Console.ReadLine();
            if (input == null)
            {
                return GetHabitTitle();
            }
            return input;
        }
        public int GetId()
        {
            Console.Write("Enter habit ID: ");
            string input = Console.ReadLine();
            int id;
            while (true)
            {
                if (Int32.TryParse(input, out id)) return id;
                else CommonMessages.IncorrectNumeric();
            }
        }
        
        public void DeleteHabit()
        {
            int id = GetId();
            db.DeleteData(id);
        }

        public void UpdateHabit()
        {
            int id = GetId();
            db.UpdateData(id);
        }

        public void GetData()
        {
            var habitTable = db.LoadData();
            Console.WriteLine("------------------");
            foreach (Habit habits in habitTable)
            {
                Console.WriteLine($"{habits.Id} - Date:{habits.Date.ToShortDateString()} Title:{habits.Title} - Quantity:{habits.Quantity} {habits.Unit}");
            }
            Console.WriteLine("------------------");
        }
    }
}
