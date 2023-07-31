using Domain.Orders;
using Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

internal sealed class LineItemConfiguration : IEntityTypeConfiguration<LineItem>
{
    public void Configure(EntityTypeBuilder<LineItem> builder)
    {
        builder.HasKey(li => li.Id);
        
        builder.Property(li => li.Id).HasConversion(
            lineItemId => lineItemId.Value,
            value => LineItemId.Create(value));

        builder.HasOne<Product>()
            .WithMany()
            .HasForeignKey(li => li.ProductId)
            .IsRequired();

        builder.OwnsOne(li => li.Price);
    }
}