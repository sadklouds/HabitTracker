using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HabitTracker.Models;

namespace HabitTracker
{
    public interface IDataAccess
    {
        void ConnectDB();

        List<Habit> LoadData();

        public void InsertData(string date, string title, float quantity, string unit);

        public void DeleteData(int Id);

        public void UpdateData(int Id);
    }
}
