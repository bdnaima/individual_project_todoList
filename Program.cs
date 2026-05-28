
TaskManager taskManager = new TaskManager();
taskManager.LoadFile();

void PrintOption(string option, string label)
{
    Console.Write("(");
    Console.ForegroundColor = ConsoleColor.DarkMagenta;
    Console.Write(option);
    Console.ResetColor();
    Console.Write(") ");
    Console.WriteLine(label);
}

while (true)
{
    Console.Clear();
    Console.Write("Welcome to ToDo");
    Console.ForegroundColor = ConsoleColor.DarkMagenta;
    Console.WriteLine("LY");
    Console.ResetColor();

    int doneCount = taskManager.CountDone();
    int notDoneCount = taskManager.CountNotDone();

    string todoText = "";
    string doneText = "";

    if (notDoneCount == 1)
    {
        todoText = "task";
    }
    else
    {
        todoText = "tasks";
    }
    if (doneCount == 1)
    {
        doneText = "task is";
    }
    else
    {
        doneText = "tasks are";
    }

    Console.WriteLine($"You have {notDoneCount} {todoText} todo and {doneCount} {doneText} done!");
    Console.WriteLine();

    Console.WriteLine("Pick an option: ");
    Console.WriteLine();
    PrintOption("1", "Show tasks");
    PrintOption("2", "Add task");
    PrintOption("3", "Manage task");
    PrintOption("4", "Save and quit");

    string? choice = Console.ReadLine()?.Trim();

    if (choice == "1")
    {
        Console.Clear();

        Console.WriteLine("How would you like to sort tasks?");
        Console.WriteLine("1. By Date");
        Console.WriteLine("2. By Project");
        Console.WriteLine("3. No sorting");

        string? sortChoice = Console.ReadLine()?.Trim();

        Console.Clear();

        if (sortChoice == "1")
        {
            taskManager.ShowSortedByDate();
        }
        else if (sortChoice == "2")
        {
            taskManager.ShowSortedByProject();
        }
        else
        {
            taskManager.ShowTasks();
        }
    }
    else if (choice == "2")
    {
        Console.Clear();
        taskManager.AddTask();
    }
    else if (choice == "3")
    {
        Console.Clear();
        taskManager.ShowTasks();

        Console.WriteLine("Manage Task:");
        Console.WriteLine("1. Edit task");
        Console.WriteLine("2. Mark as done");
        Console.WriteLine("3. Remove task");

        string? action = Console.ReadLine()?.Trim();

        if (action == "1")
        {
            taskManager.EditTask();
        }
        else if (action == "2")
        {
            taskManager.MarkAsDone();

        }
        else if (action == "3")
        {
            taskManager.RemoveTask();
        }
        else
        {
            Console.WriteLine("Invalid option");
        }
        Console.Clear();
        taskManager.ShowTasks();

    }
    else if (choice == "4")
    {
        taskManager.SaveToFile();
        break;
    }
    else
    {
        Console.WriteLine("Wrong choice!");
    }

    Console.WriteLine();
    Console.Write("Press any key to continue ");
    Console.ReadKey();
    Console.Clear();
}

