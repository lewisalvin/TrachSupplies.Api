namespace TrachSupplies.Api.Dtos;

public record class CustomerDto
(
    int Id,
    string FirstName,
    string LastName,
    string Address,
    string Email,
    string TrachType

);
