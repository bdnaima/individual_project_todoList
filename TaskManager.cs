
class TaskManager {
    List<TodoTask> todoItems = new List<TodoTask>();
    public void AddTask() {

        while(true) {
            Console.WriteLine("Enter task title:"); 
            string userInputTitle = Console.ReadLine() ?? "";

            if (userInputTitle.ToLower().Trim() == "q") {
                break;
            }

            Console.WriteLine("Enter project:");
            string userInputProject = Console.ReadLine() ?? "";

            if (userInputProject.ToLower().Trim() == "q") {
                break;
            }

            Console.WriteLine("Enter date:");
            string userInputDate = Console.ReadLine() ?? "";
            
            DateTime dueDate = DateTime.Parse(userInputDate);
            
            if(userInputDate.ToLower().Trim() == "q") {
                break;
            }

            TodoTask todoList = new TodoTask(userInputTitle, userInputProject, dueDate);
            todoItems.Add(todoList);
            Console.WriteLine("Task added successfully!");
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