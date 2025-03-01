using System.ComponentModel.DataAnnotations;

namespace TrachSupplies.Api.Dtos;

public record class CreateCustomerDto
(
    [Required][StringLength(50)] string FirstName,
    [Required][StringLength(50)] string LastName,
    [Required] string Address,
    [Required] string Email,
    string TrachType
);
