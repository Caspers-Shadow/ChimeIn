using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace MauiApp2
{
    public class Mood
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public int UserID { get; set; } // Foreign key to the User table
        public string MoodType { get; set; } // e.g., "Happy", "Sad", "Angry"
        public DateTime Date { get; set; } // Date of the mood entry
        public string Notes { get; set; } // Additional notes about the mood
    }
}
