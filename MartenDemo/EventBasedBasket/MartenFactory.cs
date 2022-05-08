using EventBasedBasket.Events;
using Marten;

namespace EventBasedBasket;

internal static class MartenFactory
{
    public static DocumentStore GetStore()
    {
        return DocumentStore.For(configure =>
        {
            configure.Connection("server=localhost; port=5432; user id=postgres; password=postgres; database=newsAPI;");
            configure.DatabaseSchemaName = "event_basket";
            configure.AutoCreateSchemaObjects = Weasel.Core.AutoCreate.All;

            configure.Events.AddEventType(typeof(BasketCreated));
            configure.Events.AddEventType(typeof(ProductAdded));
            configure.Events.AddEventType(typeof(ProductCountChanged));
            configure.Events.AddEventType(typeof(ProductRemoved));
            configure.Events.AddEventType(typeof(DiscountApplied));
            configure.Events.AddEventType(typeof(BasketClosed));
        });
    }
}
