using System;

namespace TrachSupplies.Api.Entities;

public class TrachType
{
    public int Id { get; set; }

// required means no nulls
    public required string Name { get; set; }
}
