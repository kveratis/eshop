namespace Application.Orders.Create;

public sealed record CreateOrderResponse(string OrderId, bool Success, string Message = "");