namespace Domain.Orders;

public sealed record OrderId
{
    private OrderId(Guid value) => Value = value;

    public Guid Value { get; init; }

    public static OrderId Create()
    {
        return new OrderId(Guid.NewGuid());
    }

    public static OrderId Create(Guid value)
    {
        return new OrderId(value);
    }

    public static OrderId? Create(string value)
    {
        if (Guid.TryParse(value, out var myId))
        {
            return new OrderId(myId);
        }

        return null;
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}