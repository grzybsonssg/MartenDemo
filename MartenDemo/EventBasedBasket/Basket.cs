using EventBasedBasket.Events;

public class Basket
{
    public Guid Id { get; private set; }
    public double Discount { get; private set; }
    public string OrderId { get; private set; }
    public List<Item> Items { get; } = new List<Item>();

    public decimal CalculateTotal()
        => Items.Sum(e => e.Count * e.Price) * (100 - (decimal)Discount) / 100;

    public override string ToString() => $"Basket: {Id}\r\nItemsCount: {Items.Count}\r\nDiscount: {Discount}\r\nOrderId: {OrderId}\r\nTotal: {CalculateTotal()}\r\nItems: \r\n{string.Join("\r\n", Items)}";

    public void Apply(ProductAdded @event)
        => Items.Add(new Item(@event.Sku, @event.Count, @event.Price));
    public void Apply(ProductRemoved @event)
        => Items.Remove(Items.Single(e => e.Sku == @event.Sku));
    public void Apply(ProductCountChanged @event)
        => Items.Single(e => e.Sku == @event.Sku).Count = @event.Count;
    public void Apply(DiscountApplied @event)
        => Discount = @event.Discount;
    public void Apply(BasketClosed @event)
        => OrderId = @event.OrderId;

    public class Item
    {
        public string Sku { get; }
        public decimal Price { get; }
        public int Count { get; set; }

        internal Item(string sku, int count, decimal price)
        {
            Sku = sku;
            Count = count;
            Price = price;
        }

        public override string ToString() => $"{Count}x {Sku}: {Price}";
    }
}