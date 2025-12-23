using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
namespace SmartToDoList
{
    public class TodoManager
    {
        private List<TodoItem> todos = new();
        private const string FilePath = "todos.json";

        public void AddTask(string title, string priority, string description, DateTime dueDate)
        {
            int id = todos.Count == 0 ? 1 : todos[todos.Count - 1].Id + 1;

            todos.Add(new TodoItem(id, title, priority, description, dueDate));
            SaveToFile();
        }

        public void ViewTasks()
        {
            if (todos.Count == 0)
            {
                Console.WriteLine("No tasks found!");
                return;
            }
            foreach (var todo in todos)
            {
                string status = todo.IsCompleted ? "✔" : " ";
                string overdue = (!todo.IsCompleted && todo.DueDate < DateTime.Now) ? "OverDue" : "";
                Console.WriteLine(

                        $"{todo.Id}. [{status}] {todo.Title} ({todo.Priority}) | Due: {todo.DueDate:yyyy-MM-dd}  || [{todo.Description}]"
                    );
            }
        }

        public void CompleteTask(int id)
        {
            var task = todos.FirstOrDefault(t => t.Id == id); //Search the list for a task whose Id equals the given id. If found, store it in task. If not found, task becomes null.
            if (task != null)
            {
                task.IsCompleted = true;
                SaveToFile();
            }
        }
        public void DeleteTask(int id)
        {
            todos.RemoveAll(t => t.Id == id);
            SaveToFile();
        }
        public void LoadFromFile()
        {
            if (File.Exists(FilePath))
            {
                //reads the json file as async strinf
                var json = File.ReadAllText(FilePath);
                //deserialiazting the json file big string back into a list
                todos = JsonSerializer.Deserialize<List<TodoItem>>(json) ?? new(); //It loads all the saved tasks from the JSON file into the program when the app starts.
            }
        }

        private void SaveToFile()
        {
            var json = JsonSerializer.Serialize(todos, new JsonSerializerOptions
            {
                WriteIndented = true
            }
                );
            File.WriteAllText(FilePath, json);
        }
        public void ShowReminders()
        {
            Console.WriteLine("\n REMINDERS");

            var upcomingTasks = todos
                .Where(t => !t.IsCompleted && t.DueDate <= DateTime.Now.AddHours(24))
                .ToList();

            if (upcomingTasks.Count == 0)
            {
                Console.WriteLine("No upcoming tasks.");
                return;
            }

            foreach (var task in upcomingTasks)
            {
                if (task.DueDate.HasValue)
                {
                    TimeSpan remaining = task.DueDate.Value - DateTime.Now;


                    Console.WriteLine(
                        $"{task.Title} | Due in {remaining.Hours}h {remaining.Minutes}m"
                    );
                }
            }

        }
    }
}
