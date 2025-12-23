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

        public void AddTask(string title, string priority, string description)
        {
            //int id = todos.Count == 0 ? 1 : todos[^1].Id + 1;
            //or we can us e a simpler techn.
            int id;
            if (todos.Count == 0)
            {
                id = 1;
            }
            else
            {
                id = todos[todos.Count - 1].Id; // tkae the Id of the last item by using count to getthe number form the last index and then increment the iD
            }
            todos.Add(new TodoItem(id, title, priority, description));
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
                Console.WriteLine(

                        $"{todo.Id}. [{(todo.IsCompleted ? "Yes" : " ")}] {todo.Title} ({todo.Priority}) : [{todo.Description}]"
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
            var json = JsonSerializer.Serialize(todos.Count, new JsonSerializerOptions
            {
                WriteIndented = true
            }
                );
            File.WriteAllText(FilePath, json);
        }

    }
}
