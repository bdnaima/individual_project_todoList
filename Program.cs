Console.WriteLine("Welcome to ToDoLy");
Console.WriteLine("You have X tasks todo and Y tasks are done!");

TaskManager taskManager = new TaskManager();
taskManager.AddTask();

Console.Write("Title".PadRight(21));
Console.Write("Project".PadRight(21));
Console.Write("Date".PadRight(21));
Console.Write("Status");
Console.WriteLine("\n--------------------------------------------------------------------------");

taskManager.ShowTasks();