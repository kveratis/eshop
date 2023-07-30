using MediatR;

namespace Application.Orders.Create;

public sealed record CreateOrderCommand(Guid CustomerId) : IRequest;