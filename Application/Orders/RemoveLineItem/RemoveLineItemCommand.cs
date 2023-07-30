using Domain.Orders;
using MediatR;

namespace Application.Orders.RemoveLineItem;

public sealed record RemoveLineItemCommand(OrderId OrderId, LineItemId LineItemId) : IRequest;
