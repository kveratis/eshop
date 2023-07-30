﻿using Application.Data;
using Domain.Customers;
using Domain.Orders;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public sealed class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}