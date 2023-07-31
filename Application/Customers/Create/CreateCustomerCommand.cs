using MediatR;

namespace Application.Customers.Create;

public sealed record CreateCustomerCommand(string Name, string Email) : IRequest<CreateCustomerResponse>;