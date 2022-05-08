using Marten;
using Marten.Schema.Identity;

namespace SimpleToDoList.Core;

internal class MartenFactory
{
    public static DocumentStore GetStore()
    {
        return DocumentStore.For(configure => {
            configure.Connection("server=localhost; port=5432; user id=postgres; password=postgres; database=newsAPI;");
            configure.DatabaseSchemaName = "todo";
            configure.AutoCreateSchemaObjects = Weasel.Core.AutoCreate.All;

            configure.RegisterDocumentType<ToDoList>();
            configure.Schema.For<User>().IdStrategy(new NoOpIdGeneration());

            #region Index
            //configure.Schema.For<ToDoList>().Index(e => e.UserId);
            #endregion

            #region Duplicated field
            //configure.Schema.For<ToDoList>().Duplicate(e => e.DueDate);
            #endregion region
        });
    }
}
