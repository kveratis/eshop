using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Orders.RemoveLineItem;

public sealed class RemoveLineItemCommandHandler : IRequestHandler<RemoveLineItemCommand>
{
    private readonly IApplicationDbContext _context;

    public RemoveLineItemCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(RemoveLineItemCommand request, CancellationToken cancellationToken)
    {
        // Pragmatic Tradeoff of only loading the order with the specific lineItem needed rather than the whole aggregate
        // This has better performance as it is loading less data, but breaks the purity of DDD.
        var order = await _context
            .Orders
            .Include(o => o.LineItems.Where(li => li.Id == request.LineItemId))
            .SingleOrDefaultAsync(o => o.Id == request.OrderId, cancellationToken);

        if (order is null)
        {
            return;
        }

        order.RemoveLineItem(request.LineItemId);

        await _context.SaveChangesAsync(cancellationToken);
    }
}