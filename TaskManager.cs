
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
    // void Remove();

}