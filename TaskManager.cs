using System.Text.Json;
class TaskManager {
   List<TodoTask> tasks = new List<TodoTask>();
    public void AddTask() {

        Console.WriteLine("Enter task title:"); 
        string userInputTitle = Console.ReadLine() ?? "";

        Console.WriteLine("Enter project:");
        string userInputProject = Console.ReadLine() ?? "";
        
        Console.WriteLine("Enter date:");
        string? userInputDate = Console.ReadLine();

        DateTime dueDate;
        bool success = DateTime.TryParse(userInputDate, out dueDate);

        if (userInputDate == "") { // If user didn't type anything, set todays date
            success = true;
            dueDate = DateTime.Now;
        }

        if (success) {
                TodoTask task = new TodoTask(
                userInputTitle, 
                userInputProject,
                dueDate,
                TaskStatus.NotDone
            );
            
            tasks.Add(task);
            Console.WriteLine("Task added successfully!");
        } else {
            Console.WriteLine("Invalid date format. Should in this form: 2026-05-30");
        }
    }


    public void ShowTasks () {
        Console.WriteLine(TodoTask.GetHeader());
        Console.WriteLine(TodoTask.GetDivider());
        if (tasks.Count == 0) {
            Console.WriteLine("No tasks");
        }

        foreach(TodoTask task in tasks) {
            Console.WriteLine(task);
        }
    }

    public void MarkAsDone() {
        int id;
        Console.Write("Task ID: ");
        string userInput = Console.ReadLine() ?? "";
        int.TryParse(userInput, out id);

        foreach(TodoTask task in tasks) {
            if(id == task.Id) {
                task.Status = TaskStatus.Done;
            }
        }
    }
    // void EditTask();
    public void RemoveTask() {
        TodoTask? taskToRemove = null;
        int id;
        Console.Write("Task ID: ");
        string userInput = Console.ReadLine() ?? "";
        if(int.TryParse(userInput, out id)) {

            foreach(TodoTask task in tasks) {
                if(id == task.Id) {
                    taskToRemove = task;
                }
            }

            if (taskToRemove != null) {
                tasks.Remove(taskToRemove);
            }
        }
    }

    public void SaveToFile() {
        string jsonString = JsonSerializer.Serialize(tasks);
        File.WriteAllText("tasks.json", jsonString);
    }

    public void LoadFile() {
        string jsonString = File.ReadAllText("tasks.json");
        tasks = JsonSerializer.Deserialize <List<TodoTask>>(jsonString);
    }

    public int CountDone () {
        int doneCounter = 0;

        foreach (TodoTask task in tasks) {
            if(task.Status == TaskStatus.Done) {
                doneCounter = doneCounter + 1;
            } 
        }
        return doneCounter;
    }

    public int CountNotDone () {
        int notDoneCounter = 0;

        foreach (TodoTask task in tasks) {
            if(task.Status == TaskStatus.NotDone) {
                notDoneCounter = notDoneCounter + 1;
            } 
        }
        return notDoneCounter;
    }
    
}