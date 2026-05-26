
class TaskManager {
    List<TodoTask> todoItems = new List<TodoTask>();
     DateTime dueDate;
    public void AddTask() {

        while(true) {
            Console.WriteLine("Enter task title:"); 
            string? userInputTitle = Console.ReadLine();

            if (userInputTitle == null) break;
            if (userInputTitle.ToLower().Trim() == "q") break;

            Console.WriteLine("Enter project:");
            string? userInputProject = Console.ReadLine();

            if (userInputProject == null) break;
            if (userInputProject.ToLower().Trim() == "q") break;

            Console.WriteLine("Enter date:");
            string? userInputDate = Console.ReadLine();

            if (userInputDate == null) break;
            if (userInputDate.ToLower().Trim() == "q") break;

            bool success = DateTime.TryParse(userInputDate, out dueDate);

            if (success) {
                 TodoTask task = new TodoTask(
                    userInputTitle, 
                    userInputProject,
                    dueDate,
                    TaskStatus.NotDone
                );
                
                todoItems.Add(task);
                Console.WriteLine("Task added successfully!");
            } else {
                Console.WriteLine("Invalid date format. Should in this form: 2026-05-30");
            }
        }
    }

    public void ShowTasks () {
       
        foreach(TodoTask item in todoItems) {
            
            Console.WriteLine(item);
        }
    }


    // void MarkAsDone();
    // void EditTask();
    // void Remove();


}