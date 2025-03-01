using System;

namespace TrachSupplies.Api.Entities;

public class Customer
{
    public int Id { get; set; }

    public required string FirstName { get; set; }

    public required string LastName { get; set; }

    public required string Address { get; set; }

    public required string Email { get; set; }

    public int TrachTypeId { get; set; }

    // may or may not be null.  So TrachType? accepts null.
    public TrachType? Trachtype { get; set; } 
}
