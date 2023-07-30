using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Orders.Create;

internal sealed class CreatePaymentRequestEventHandler : INotificationHandler<OrderCreatedEvent>
{
    private readonly ILogger<CreatePaymentRequestEventHandler> _logger;

    public CreatePaymentRequestEventHandler(ILogger<CreatePaymentRequestEventHandler> logger)
    {
        _logger = logger;
    }

    public async Task Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Starting payment request for order {@OrderId}", notification.OrderId);

        await Task.Delay(2000, cancellationToken);

        _logger.LogInformation("Payment request for order {@OrderId} started", notification.OrderId);
    }
}