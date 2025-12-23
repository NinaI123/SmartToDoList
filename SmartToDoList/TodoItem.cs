using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
        public string Description { get; set; } = "";
        public DateTime? DueDate { get; set; }
        public TodoItem() {}
        public TodoItem(int id, string title, string priority, string description, DateTime dueDate)
        {
            Id = id;
            Title = title;
            Priority = priority;
            IsCompleted = false;
            DueDate = dueDate;
            Description = description;
            
        }
    }

}
