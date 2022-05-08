namespace EventBasedBasket.Events;

public record BasketCreated();
public record ProductAdded(string Sku, int Count, decimal Price);
public record ProductCountChanged(string Sku, int Count);
public record ProductRemoved(string Sku);
public record DiscountApplied(double Discount);
public record BasketClosed(string OrderId);