namespace Domain.Customers;

public class Customer
{
    public CustomerId Id { get; private set; }
    
    public string Email { get; private set; } = string.Empty;

    public string Name { get; private set; } = string.Empty;

    public static Customer Create(string name, string email)
    {
        var customer = new Customer
        {
            Id = CustomerId.Create(),
            Name = name,
            Email = email
        };

        return customer;
    }
}