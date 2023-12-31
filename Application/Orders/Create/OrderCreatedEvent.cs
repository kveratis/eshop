﻿using Domain.Orders;
using MediatR;

namespace Application.Orders.Create;

public sealed record OrderCreatedEvent(OrderId OrderId) : INotification;
