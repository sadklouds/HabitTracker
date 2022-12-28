using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HabitTracker.Models
{
    public class Habit
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public float Quantity { get; set; }

        public string Unit { get; set; }

        public Habit (int id, DateTime date, string title, float quantity, string unit)
        {
            Id = id;
            Date = date;
            Title = title;
            Quantity = quantity;
            Unit = unit;
        }
    }
}
