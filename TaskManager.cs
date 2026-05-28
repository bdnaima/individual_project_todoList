using System.Text.Json;
class TaskManager
{
    List<TodoTask> tasks = new List<TodoTask>();

    public void AddTask()
    {

        Console.WriteLine("Enter task title:");
        string userInputTitle = Console.ReadLine() ?? "";

        Console.WriteLine("Enter project:");
        string userInputProject = Console.ReadLine() ?? "";

        Console.WriteLine("Enter date (yyyy-mm-dd):");
        string? userInputDate = Console.ReadLine();

        DateTime dueDate;
        bool success = DateTime.TryParse(userInputDate, out dueDate);

        if (userInputDate == "")
        { // If user didn't type anything, set todays date
            success = true;
            dueDate = DateTime.Now;
        }

        if (success && dueDate.Date < DateTime.Today)
        {
            success = false;
        }

        if (success)
        {
            TodoTask task = new TodoTask(
            userInputTitle,
            userInputProject,
            dueDate,
            TaskStatus.NotDone
        );

            tasks.Add(task);
            Console.WriteLine("Task added successfully!");
        }
        else
        {
            Console.WriteLine("Invalid date. Please enter today or a future date (yyyy-mm-dd).");
        }
    }


    public void ShowTasks()
    {
        Console.WriteLine(TodoTask.GetHeader());
        Console.WriteLine(TodoTask.GetDivider());
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks");
        }

        foreach (TodoTask task in tasks)
        {
            Console.WriteLine(task);
        }
    }

    public void EditTask()
    {
        Console.Write("Task ID: ");
        int id = int.Parse(Console.ReadLine() ?? "0");

        foreach (var task in tasks)
        {
            if (task.Id == id)
            {
                Console.Write("New title: ");
                task.Title = Console.ReadLine() ?? task.Title;

                Console.Write("New project: ");
                task.Project = Console.ReadLine() ?? task.Project;

                Console.Write("New date (yyyy-mm-dd): ");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime newDate))
                {
                    task.DueDate = newDate;
                }

                Console.WriteLine("Task updated!");
                return;
            }
        }

        Console.WriteLine("Task not found.");
    }

    public void MarkAsDone()
    {
        int id;
        Console.Write("Task ID: ");
        string userInput = Console.ReadLine() ?? "";
        int.TryParse(userInput, out id);

        foreach (TodoTask task in tasks)
        {
            if (id == task.Id)
            {
                task.Status = TaskStatus.Done;
            }
        }
    }

    public void RemoveTask()
    {
        TodoTask? taskToRemove = null;
        int id;
        Console.Write("Task ID: ");
        string userInput = Console.ReadLine() ?? "";
        if (int.TryParse(userInput, out id))
        {

            foreach (TodoTask task in tasks)
            {
                if (id == task.Id)
                {
                    taskToRemove = task;
                }
            }

            if (taskToRemove != null)
            {
                tasks.Remove(taskToRemove);
            }
        }
    }

    public void ShowSortedByDate()
    {
        var sortedList = tasks.OrderBy(task => task.DueDate).ToList();
        Console.WriteLine(TodoTask.GetHeader());
        Console.WriteLine(TodoTask.GetDivider());

        foreach (TodoTask task in sortedList)
        {
            Console.WriteLine(task);
        }
    }

    public void ShowSortedByProject()
    {
        var sortedList = tasks.OrderBy(task => task.Project).ToList();
        Console.WriteLine(TodoTask.GetHeader());
        Console.WriteLine(TodoTask.GetDivider());

        foreach (TodoTask task in sortedList)
        {
            Console.WriteLine(task);
        }
    }

    public void SaveToFile()
    {
        string jsonString = JsonSerializer.Serialize(tasks);
        File.WriteAllText("tasks.json", jsonString);
    }

    public void LoadFile()
    {
        if (!File.Exists("tasks.json")) return;
        string jsonString = File.ReadAllText("tasks.json");
        tasks = JsonSerializer.Deserialize<List<TodoTask>>(jsonString) ?? new List<TodoTask>();

        if (tasks.Count > 0)
        {
            TodoTask.SetCounter(tasks.Max(t => t.Id) + 1);
        }
        else
        {
            TodoTask.SetCounter(100);
        }
    }

    public int CountDone()
    {
        int doneCounter = 0;

        foreach (TodoTask task in tasks)
        {
            if (task.Status == TaskStatus.Done)
            {
                doneCounter = doneCounter + 1;
            }
        }
        return doneCounter;
    }

    public int CountNotDone()
    {
        int notDoneCounter = 0;

        foreach (TodoTask task in tasks)
        {
            if (task.Status == TaskStatus.NotDone)
            {
                notDoneCounter = notDoneCounter + 1;
            }
        }
        return notDoneCounter;
    }


}