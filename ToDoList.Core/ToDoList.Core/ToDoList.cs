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
        var s = $"Name: {Name}\r\nUserId: {UserId}\r\n";
        foreach (var task in Tasks)
            s += $"* {task}\r\n";
        return s;
    }
}

public class ToDoTask
{
    public string Name { get; init; }
    public bool IsDone { get; private set; }

    public void Done() => IsDone = true;

    public override string ToString()
        => $"{Name}: {(IsDone ? "OK" : "NOK")}";
}