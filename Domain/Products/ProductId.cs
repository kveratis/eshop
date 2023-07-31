namespace Domain.Products;

public sealed record ProductId
{
    private ProductId(Guid value) => Value = value;

    public Guid Value { get; init; }

    public static ProductId Create()
    {
        return new ProductId(Guid.NewGuid());
    }

    public static ProductId Create(Guid value)
    {
        return new ProductId(value);
    }

    public static ProductId? Create(string value)
    {
        if (Guid.TryParse(value, out var myId))
        {
            return new ProductId(myId);
        }

        return null;
    }

    public override string ToString()
    {
        return Value.ToString();
    }
}
