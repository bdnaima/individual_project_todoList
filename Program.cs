Console.WriteLine("Welcome to ToDoLy");
Console.WriteLine("You have X tasks todo and Y tasks are done!");

TaskManager taskManager = new TaskManager();
taskManager.AddTask();

Console.WriteLine("----------------------------------------");
taskManager.ShowTasks();