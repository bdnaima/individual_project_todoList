
TaskManager taskManager = new TaskManager();
taskManager.LoadFile();

void PrintOption (string option, string label) {
    Console.Write("(");
    Console.ForegroundColor = ConsoleColor.DarkMagenta;
    Console.Write(option);
    Console.ResetColor();
    Console.Write(") ");
    Console.WriteLine(label);
}

while (true) {
    Console.Write("Welcome to ToDo");
    Console.ForegroundColor = ConsoleColor.DarkMagenta;
    Console.WriteLine("LY");
    Console.ResetColor();

    int doneCount = taskManager.CountDone();
    int notDoneCount = taskManager.CountNotDone();
    
    string todoText = "";
    string doneText = "";
    string doneVerb = "";

    if (notDoneCount == 1) {
        todoText = "task";
    } else {
        todoText = "tasks";
    }
     if (doneCount == 1) {
        doneText = "task is";
    } else {
        doneText = "tasks are";
    }


    Console.WriteLine($"You have {taskManager.CountNotDone()} {todoText} todo and {taskManager.CountDone()} {doneText} done!");
    Console.WriteLine();

    Console.WriteLine("Pick an option: ");
    Console.WriteLine();
    PrintOption("1", "Show tasks");
    Console.WriteLine();
    PrintOption("2", "Add task");
    Console.WriteLine();
    PrintOption("3", "Edit task");
    Console.WriteLine();
    PrintOption("4", "Save and quit");

    string? choice = Console.ReadLine()?.Trim();

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
       taskManager.SaveToFile();
       break;
    }
    else {
        Console.WriteLine("Wrong choice!");
    }

    Console.WriteLine();
    Console.Write("Press any key to continue ");
    Console.ReadKey();
    Console.Clear();
}