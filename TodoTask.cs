class TodoTask {
    public int Id {get; set;}
    public string Title {get; set;}
    public string  Project {get; set;}
    public DateTime DueDate {get; set;}

    public TaskStatus Status {get; set;}

    static int counter = 100;

    public TodoTask (string title, string project, DateTime dueDate, TaskStatus status) {
        Id = counter;
        counter ++;
        Title = title; 
        Project = project;
        DueDate = dueDate;
        Status = status;
    }

    public static string GetHeader() {
         return $"    {"Title".PadRight(20)} {"Project".PadRight(20)} {"Date".PadRight(20)} {"ID".PadRight(5)}"; 
    }

    public static string GetDivider() {
        return "--------------------------------------------------------------------------";
    }

    public override string ToString () {
        string stat = Status == TaskStatus.Done ?  "[✓]" : "[ ]";
        return $"{stat} {Title.PadRight(20)} {Project.PadRight(20)} {DueDate.ToString("yyyy-MM-dd").PadRight(20)} {Id.ToString().PadRight(5)}";
    }
}

enum TaskStatus {
    Done,
    NotDone
}