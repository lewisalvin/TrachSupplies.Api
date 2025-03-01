using System.ComponentModel.DataAnnotations;

namespace TrachSupplies.Api.Dtos;

public record class UpdateCustomerDto
(
    [Required][StringLength(50)] string firstName,
    [Required][StringLength(50)] string lastName,
    [Required] string address,
    [Required] string email
);
