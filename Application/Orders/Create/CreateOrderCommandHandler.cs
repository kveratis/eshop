using Application.Data;
using Domain.Customers;
using Domain.Orders;
using MediatR;

namespace Application.Orders.Create;

public sealed class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, CreateOrderResponse>
{
    private readonly IApplicationDbContext _context;
    private readonly IPublisher _publisher;

    public CreateOrderCommandHandler(IApplicationDbContext context, IPublisher publisher)
    {
        _context = context;
        _publisher = publisher;
    }

    public async Task<CreateOrderResponse> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var customer = await _context.Customers.FindAsync(CustomerId.Create(request.CustomerId), cancellationToken);

        if (customer is null)
        {
            return new CreateOrderResponse(string.Empty, false, "Customer Doesn't Exist");
        }

        var order = Order.Create(customer.Id);

        _context.Orders.Add(order);

        await _context.SaveChangesAsync(cancellationToken);

        await _publisher.Publish(new OrderCreatedEvent(order.Id), cancellationToken);

        return new CreateOrderResponse(order.Id.ToString(), true);
    }
}