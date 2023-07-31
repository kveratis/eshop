using Application.Data;
using Domain.Customers;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Customers.Create;

public sealed class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CreateCustomerResponse>
{
    private readonly IApplicationDbContext _context;
    private readonly ILogger<CreateCustomerCommandHandler> _logger;

    public CreateCustomerCommandHandler(IApplicationDbContext context, ILogger<CreateCustomerCommandHandler> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<CreateCustomerResponse> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Creating new customer {@CustomerName} with Email {@CustomerEmail}", request.Name, request.Email);

        var customer = Customer.Create(request.Name, request.Email);

        _context.Customers.Add(customer);

        await _context.SaveChangesAsync(cancellationToken);

        _logger.LogInformation("Created customer {@CustomerId}: {@CustomerName} <{@CustomerEmail}>", customer.Id, customer.Name, customer.Email);

        return new CreateCustomerResponse(customer.Id.ToString(), true);
    }
}