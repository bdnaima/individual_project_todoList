
TaskManager taskManager = new TaskManager();

void PrintOption (string option, string label) {
    Console.Write("(");
    Console.ForegroundColor = ConsoleColor.DarkMagenta;
    Console.Write(option);
    Console.ResetColor();
    Console.Write(") ");
    Console.WriteLine(label);
}

while (true) {
    Console.WriteLine("Welcome to ToDoLy");
    Console.WriteLine("You have X tasks todo and Y tasks are done!");
    Console.WriteLine();

    Console.WriteLine("Pick an option: ");
    PrintOption("1", "Show tasks");
    PrintOption("2", "Add task");
    PrintOption("3", "Edit task");
    PrintOption("4", "Save and quit");

    string? choice = Console.ReadLine();

    if (choice == "1") {
        Console.Clear();
        taskManager.ShowTasks();
    }
    else if (choice == "2") {
        Console.Clear();
        taskManager.AddTask();
    }
    else if (choice == "3") {
        taskManager.MarkAsDone();
    } 
    else if(choice == "4") {
         break;
    }
    else {
        Console.WriteLine("Wrong choice!");
    }

    Console.WriteLine("Press any key to continue");
    Console.ReadKey();
    Console.Clear();
}