// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using SmartToDoList;

class Program
{
    static void Main()
    {
        TodoManager manager = new();
        manager.LoadFromFile();

        while (true)
        {
            Console.WriteLine("\n--- Smart To-Do List ---");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. View Tasks");
            Console.WriteLine("3. Complete Task");
            Console.WriteLine("4. Delete Task");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    //string choice = Console.ReadLine();
                    Console.Write("Task title: ");
                    string title = Console.ReadLine();

                    Console.Write("Priority (Low/Medium/High): ");
                    string priority = Console.ReadLine();

                    Console.WriteLine("Give a task description:");
                    string description = Console.ReadLine();

                    manager.AddTask(title, priority, description);
                    break;
                case "2":
                    manager.ViewTasks();

                    break;
                case "3":
                    Console.WriteLine("Enter Task Id to complete:");
                    manager.CompleteTask(int.Parse(Console.ReadLine()));
                    break;
                case "4":
                    Console.Write("Enter task ID to delete:");
                    manager.DeleteTask(int.Parse(Console.ReadLine()));
                    break;
                case "5":
                    return;
            }


        }
            
    }
}