using Marten;

namespace SimpleToDoList.Core;

internal class MartenFactory
{
    public static DocumentStore GetStore()
    {
        return DocumentStore.For(configure => {
            configure.Connection("server=localhost; port=5432; user id=postgres; password=postgres; database=newsAPI;");
            configure.DatabaseSchemaName = "todo";
            configure.AutoCreateSchemaObjects = Weasel.Core.AutoCreate.All;

            // opcjonalne
            configure.RegisterDocumentType<ToDoList>();
        });
    }
}
