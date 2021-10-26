using System;
using SQLite;

namespace AppSampledb
{
    public class TodoItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsDone { get; set; }
        public DateTime UpdatedAt { get; set; }
        
        public TodoItem()
        {
        }
    }
}


