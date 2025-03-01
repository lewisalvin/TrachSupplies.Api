using System;
using Microsoft.EntityFrameworkCore;
using TrachSupplies.Api.Entities;

namespace TrachSupplies.Api.Data;

public class TrachSuppliesContext(DbContextOptions<TrachSuppliesContext> options)
     : DbContext(options)
{
    public DbSet<Customer> Customers => Set<Customer>();

    public DbSet<TrachType> TrachTypes => Set<TrachType>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TrachType>().HasData(
            new {Id = 1, Name = "Cuffed"},
            new {Id = 2, Name = "Cuffless"}
        );
    }
}
