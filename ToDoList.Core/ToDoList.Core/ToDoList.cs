using Newtonsoft.Json;

namespace SimpleToDoList.Core;

public class ToDoList
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public int UserId { get; private set; }
    public List<ToDoTask> Tasks { get; private set; } = new List<ToDoTask>();

    [JsonConstructor]
    protected ToDoList(int id, string name, int userId, List<ToDoTask> tasks)
    {
        Id = id;
        Name = name;
        UserId = userId;
        Tasks = tasks;
    }

    public ToDoList(string name, int userId, IEnumerable<string> initialTasks)
    {
        this.Name = name;
        this.UserId = userId;
        this.Tasks = initialTasks.Select(task => new ToDoTask { Name = task }).ToList();
    }

    public void AddTask(string toDoTask) => Tasks.Add(new ToDoTask { Name = toDoTask });

    public override string ToString()
    {
        var s = $"ID: {Id}\r\nName: {Name}\r\nUserId: {UserId}\r\n";
        foreach (var task in Tasks)
            s += $"* {task}\r\n";
        return s;
    }

    #region Example data
    public static ToDoList CreateWorkDayToDoList() => new ToDoList(
        "Dzień w pracy",
        6502,
        new[]
        {
            "Nie zaspać na daily",
            "Rozpykać koszyk",
            "Odezwać sie na refinemencie",
            "Pomarudzić na XSynci"
        });

    public static ToDoList CreateWeekendToDoList() => new ToDoList(
        "Weekend",
        6502,
        new[]
        {
            "Wyspać się",
            "Pozdzierać kolana na skałach",
            "Zrobić ognisko %%%",
        });

    public static ToDoList CreateBossToDoList() => new ToDoList(
        "Weekend",
        18,
        new[]
        {
            "Podbić kolejne rynki",
            "Zarobić więcej $$$",
            "Wygrać puchar polski",
        });
    #endregion
}

public class ToDoTask
{
    public string Name { get; init; }
    public bool IsDone { get; private set; }

    [JsonConstructor]
    protected ToDoTask(string name, bool isDone)
    {
        Name = name;
        IsDone = isDone;
    }

    public ToDoTask() { }

    public void Done() => IsDone = true;

    public override string ToString()
        => $"{Name}: {(IsDone ? "OK" : "NOK")}";
}