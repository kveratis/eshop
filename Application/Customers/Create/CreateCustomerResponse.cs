namespace Application.Customers.Create;

public sealed record CreateCustomerResponse(string CustomerId, bool Success, string Message = "");