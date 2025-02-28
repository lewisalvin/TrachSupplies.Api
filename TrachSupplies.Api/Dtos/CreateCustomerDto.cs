namespace TrachSupplies.Api.Dtos;

public record class CreateCustomerDto
(
    string firstName,
    string lastName,
    string address,
    string email
);
