using EventBasedBasket;
using EventBasedBasket.Events;

Guid basketId;
var documentStore = MartenFactory.GetStore();

#region Start stream
using (var session = documentStore.OpenSession())
{
    var stream = session.Events.StartStream(
        new BasketCreated(),
        new ProductAdded("C014889", 1, 68.000M),
        new ProductAdded("C021698", 1, 65.02M));
    await session.SaveChangesAsync();

    basketId = stream.Id;
    Console.WriteLine("Basket created!");
}
#endregion

#region Querying
using (var session = documentStore.OpenSession())
{
    var events = session.Events.FetchStream(basketId);
    foreach (var @event in events)
    {
        Console.WriteLine($"{@event.Id} {@event.Sequence} {@event.Data}");
    }
}
#endregion

#region Append events
using (var session = documentStore.OpenSession())
{
    session.Events.Append(basketId,
        new ProductCountChanged("C014889", 2),
        new ProductRemoved("C021698"),
        new ProductAdded("C012294", 1, 20.03M),
        new DiscountApplied(10),
        new BasketClosed("123456789"));

    await session.SaveChangesAsync();

    Console.WriteLine("Basket Updated!");

    foreach (var @event in session.Events.FetchStream(basketId))
    {
        Console.WriteLine($"{@event.Id} {@event.Sequence} {@event.Data}");
    }
}

#endregion

#region Live aggregate
using (var session = documentStore.QuerySession())
{
    var basket = await session.Events.AggregateStreamAsync<Basket>(basketId);
    Console.WriteLine(basket);
}
#endregion
