using Domain.Customers;
using Domain.Products;

namespace Domain.Orders;

public sealed class Order
{
    private readonly List<LineItem> _lineItems = new();

    private Order()
    {
    }
    
    public OrderId Id { get; private set; }
    
    public CustomerId CustomerId { get; private set; }
    
    public OrderStatus Status { get; private set; }

    public IReadOnlyList<LineItem> LineItems => _lineItems.AsReadOnly();

    public static Order Create(Customer customer)
    {
        var order = new Order
        {
            Id = OrderId.Create(),
            CustomerId = customer.Id,
            Status = OrderStatus.Pending,
        };

        return order;
    }

    public static Order Create(CustomerId customerId)
    {
        var order = new Order
        {
            Id = OrderId.Create(),
            CustomerId = customerId,
            Status = OrderStatus.Pending,
        };

        return order;
    }
    
    public void Add(Product product)
    {
        var lineItem = new LineItem(
            LineItemId.Create(), 
            Id, 
            product.Id, 
            product.Price);

        _lineItems.Add(lineItem);
    }

    public void Add(ProductId productId, Money price)
    {
        var lineItem = new LineItem(
            LineItemId.Create(),
            Id,
            productId,
            price);
    }

    public void RemoveLineItem(LineItemId lineItemId)
    {
        var lineItem = _lineItems.FirstOrDefault(li => li.Id == lineItemId);

        if (lineItem is null)
        {
            return;
        }

        _lineItems.Remove(lineItem);
    }
}