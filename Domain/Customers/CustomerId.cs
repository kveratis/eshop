namespace Domain.Customers;

public sealed record CustomerId
{
    private CustomerId(Guid value) => Value = value;

    public Guid Value { get; init; }

    public static CustomerId Create()
    {
        return new CustomerId(Guid.NewGuid());
    }

    public static CustomerId Create(Guid value)
    {
        return new CustomerId(value);
    }

    public static CustomerId? Create(string value)
    {
        if (Guid.TryParse(value, out var myId))
        {
            return new CustomerId(myId);
        }

        return null;
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}