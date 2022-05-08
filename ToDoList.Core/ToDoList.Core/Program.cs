using Marten;
using SimpleToDoList.Core;

var documentStore = MartenFactory.GetStore();

#region Insert document
using (var session1 = documentStore.OpenSession())
{
    //var workDayList = ToDoList.CreateWorkDayToDoList();
    //var weekendList = ToDoList.CreateWeekendToDoList();
    //var bossList = ToDoList.CreateBossToDoList();
    //session1.Insert(workDayList, weekendList, bossList);
    //session1.Insert(User.DemoUsers());
    //await session1.SaveChangesAsync();
}
#endregion

#region Update document
using (var session2 = documentStore.OpenSession())
{
    //var listToModify = await session2.LoadAsync<ToDoList>(1);

    //listToModify.Tasks[0].Done();
    //listToModify.Tasks[1].Done();

    //session2.Update(listToModify);
    //await session2.SaveChangesAsync();
}
#endregion

#region Update document
//using (var dirtyTrackedSession = documentStore.DirtyTrackedSession())
//{
//    var listToModify = await dirtyTrackedSession.LoadAsync<ToDoList>(1);

//    listToModify.Tasks[2].Done();
//    listToModify.Tasks[3].Done();

//    await dirtyTrackedSession.SaveChangesAsync();
//}
#endregion


#region Delete document
//using (var session3 = documentStore.OpenSession())
//{
//    var listToDelete = await session3.LoadAsync<ToDoList>(1001);
//    session3.Delete(listToDelete);
//    session3.Delete<ToDoList>(1002);
//    await session3.SaveChangesAsync();
//}
#endregion

#region Querying
using (var querySession = documentStore.QuerySession())
{
    #region Simple Query
    //var userToDoLists = await querySession.Query<ToDoList>()
    //    .Where(e => e.UserId == 6502)
    //    .OrderBy(e => e.Id)
    //    .ToListAsync();

    //foreach (var list in userToDoLists)
    //    Console.WriteLine(list);

    #endregion

    #region Nested collection
    //var listWithCompletedTask = await querySession.Query<ToDoList>()
    //    .Where(e => e.Tasks.Any(task => task.IsDone))
    //    .ToListAsync();

    //foreach (var list in listWithCompletedTask)
    //    Console.WriteLine(list);
    #endregion

    #region Include
    //var includedUsers = new Dictionary<int, User>();
    //var allLists = await querySession.Query<ToDoList>()
    //    .Include(e => e.UserId, includedUsers)
    //    .ToListAsync();

    //foreach (var list in allLists)
    //{
    //    Console.WriteLine($"{list.Id} \"{list.Name}\", Owner {includedUsers[list.UserId]}");
    //}
    #endregion
}
#endregion