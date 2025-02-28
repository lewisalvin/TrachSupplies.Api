namespace TrachSupplies.Api.Dtos;

public record class UpdateCustomerDto
(
    string firstName,
    string lastName,
    string address,
    string email
);
