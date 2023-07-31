namespace Domain.Orders;

public sealed record LineItemId
{
    private LineItemId(Guid value) => Value = value;

    public Guid Value { get; init; }

    public static LineItemId Create()
    {
        return new LineItemId(Guid.NewGuid());
    }

    public static LineItemId Create(Guid value)
    {
        return new LineItemId(value);
    }

    public static LineItemId? Create(string value)
    {
        if (Guid.TryParse(value, out var myId))
        {
            return new LineItemId(myId);
        }

        return null;
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}