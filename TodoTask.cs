

class TodoTask {
    public string Title {get; set;}
    public string  Project {get; set;}
    public DateTime DueDate {get; set;}

    public TaskStatus Status {get; set;}

    public TodoTask (string title, string project, DateTime dueDate, TaskStatus status) {
        Title = title;
        Project = project;
        DueDate = dueDate;
        Status = status;
    }

    public override string ToString () {
        return $"{Title.PadRight(20)} {Project.PadRight(20)} {DueDate.ToString("yyyy-MM-dd").PadRight(20)} {Status}";
    }
}

enum TaskStatus {
    Done,
    NotDone
}