namespace SimpleToDoList.Core;

public class User
{
    public int Id { get; init; }
    public string Name { get; init; }

    public override string ToString() => $"{Name}";

    public static User[] DemoUsers() => new User[]
    {
        new User { Id = 6502, Name = "Maciej Grzybek" },
        new User { Id = 18, Name = "Pan Prezes"}
    };
}
