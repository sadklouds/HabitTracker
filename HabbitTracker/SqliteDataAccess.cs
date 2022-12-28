using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;using Microsoft.Data.Sqlite;
using HabitTracker.Models;
using HabitTracker.Helper;
using System.Reflection;

namespace HabitTracker
{
    public class SqliteDataAccess : IDataAccess
    {
        public string connectionString { get; } = @"Data Source=HabitTrackerDB.db";
        public void ConnectDB()
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                //create a new databse if one does not exist 

                connection.Open();
                var table = connection.CreateCommand();
                table.CommandText = @"CREATE TABLE IF NOT EXISTS habits(
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Date TEXT,
                Title TEXT,
                Quantity REAL,
                Unit TEXT)";
                table.ExecuteNonQuery();
                connection.Close();
            }
        }
        // load data from database into habit object list
        public List<Habit> LoadData()
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var output = connection.CreateCommand();
                output.CommandText = "SELECT * FROM habits";
                List<Habit> habitsTable = new List<Habit>();
                SqliteDataReader reader = output.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int Id = reader.GetInt32(0);
                        DateTime Date = DateTime.Parse(reader.GetString(1));
                        string title = reader.GetString(2);
                        float quantity = reader.GetFloat(3);
                        string unit = reader.GetString(4);
                        habitsTable.Add(new Habit(Id, Date, title, quantity, unit));
                    }
                }
                else
                {
                    CommonMessages.EmptyTable();
                    connection.Close();
                }
                connection.Close();
                return habitsTable;
            }
        }
        // create new entry in data base a crud operation
        public void InsertData(string date, string title, float quantity, string unit)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var input = connection.CreateCommand();
                input.CommandText = $"INSERT INTO habits(Date, Title, Quantity, Unit) VALUES ('{date}', '{title}', {quantity}, '{unit}')";
                try
                {
                    input.ExecuteNonQuery();
                    Console.WriteLine("Data Inserted successfully");
                    connection.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Data not Inserted");
                    Console.WriteLine(e);
                    connection.Close();
                }
            }
        }

        // Finds habits in database table and deletes id if entered id matches a database one. crud operation 
        public void DeleteData(int Id)
        {
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var input = connection.CreateCommand();
                input.CommandText = $"DELETE FROM habits WHERE Id == {Id}";
          
                int count = input.ExecuteNonQuery();
                //if the id does not equal anithing in data base then deletion failed
                if (count == 0) Console.WriteLine($"Record with id:{Id} does not exist");
                else Console.WriteLine("Record has been deleted successfully");
                connection.Close();
            }
        }

        public void UpdateData(int Id)
        {
            HabitTrackerLogic logic = new HabitTrackerLogic(); // only needs to be used here for new data input information
            using (var connection = new SqliteConnection(connectionString))
            {
                connection.Open();
                var check = connection.CreateCommand();
                check.CommandText = $"SELECT * FROM habits WHERE Id = {Id}";
                int checkRecord = Convert.ToInt32(check.ExecuteScalar()); // executes a command to database and returns result
                try
                {
                    if (checkRecord == 0)
                    {
                        Console.WriteLine($"Record with id:{Id} does not exist");
                        connection.Close();
                    }
                    else
                    {
                        // only gets new data and quantiy if record with id was found
                        string date = logic.DateValidator().ToString();
                        float quantity = logic.QuantityValidator();

                        var update = connection.CreateCommand();
                        update.CommandText = $"UPDATE habits SET Date = '{date}', Quantity = {quantity} WHERE Id = {Id}";
                        update.ExecuteNonQuery();
                        Console.WriteLine("Record has been updated successfully");
                        connection.Close();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("A problem has occured, Record could not be deleted");
                }   
            }
        }

    }
}
