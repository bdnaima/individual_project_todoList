

class TodoTask {
    public string Title {get; set;}
    public string  Project {get; set;}
    public DateTime DueDate {get; set;}

    public TaskStatus Satus {get; set;}

    public TodoTask (string title, string project, DateTime dueDate, TaskStatus status) {
        Title = title;
        Project = project;
        DueDate = dueDate;
        Status = status;
    }

    public override string ToString () {
        return $"{Title.PadRight(10)} {Project.PadRight(10)} {DueDate.ToString("yyyy-MM-dd").PadRight(10)} {Satus}";
    }
}

enum TaskStatus {
    Done,
    NotDone
}