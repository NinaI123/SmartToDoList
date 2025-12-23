using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartToDoList
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Priority { get; set; }  // Low, Medium, High
        public bool IsCompleted { get; set; }
        public string Description { get; set; }

        public TodoItem(int id, string title, string priority, string description)
        {
            Id = id;
            Title = title;
            Priority = priority;
            IsCompleted = false;
            Description = description;
        }
    }

}
