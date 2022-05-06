using SimpleToDoList.Core;

var documentStore = MartenFactory.GetStore();

#region Insert document
//using (var session = documentStore.OpenSession())
//{
//    var workDayList = CreateWorkDayToDoList();
//    var weekendList = CreateWeekendToDoList();
//    session.Insert(workDayList, weekendList);
//    await session.SaveChangesAsync();
//}
#endregion

#region Update document
//using (var session = documentStore.OpenSession())
//{
//    var listToModify = await session.LoadAsync<ToDoList>(1);

//    listToModify.Tasks[0].Done();
//    listToModify.Tasks[1].Done();

//    session.Update(listToModify);
//    await session.SaveChangesAsync();
//}
#endregion

#region Delete document
//using (var session = documentStore.OpenSession())
//{
//    var listToDelete = await session.LoadAsync<ToDoList>(1001);
//    session.Delete(listToDelete);
//    session.Delete<ToDoList>(1002);
//    await session.SaveChangesAsync();
//}
#endregion

#region Querying
using (var querySession = documentStore.QuerySession())
{

}
#endregion

#region Data
ToDoList CreateWorkDayToDoList() => new ToDoList(
        "Dzień w pracy",
        6502,
        new[]
        {
        "Nie zaspać na daily",
        "Rozpykać koszyk",
        "Odezwać sie na refinemencie",
        "Pomarudzić na XSynci"
        });

ToDoList CreateWeekendToDoList() => new ToDoList(
        "Weekend",
        6502,
        new[]
        {
        "Wyspać się",
        "Pozdzierać kolana na skałach",
        "Zrobić ognisko %%%",
        });

#endregion