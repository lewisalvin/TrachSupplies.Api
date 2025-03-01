using System;
using TrachSupplies.Api.Dtos;

namespace TrachSupplies.Api.Endpoints;

public static class TrachsEndpoints
{
    const string GetCustomerEndPointName = "GetCustomer";

    private static readonly List<CustomerDto> customers = [
        new(
            1,
            "Braxton",
            "Lewis",
            "1111 Wooden Snow Lane",
            "chasitysheri@gmail.com",
            "cuffless"),
        new(
            2,
            "Matteo",
            "Garcia",
            "2222 Capps Rd",
            "galgathg@email.com",
            "cuffed"),
        new(
            3,
            "Nikko",
            "Green",
            "3333 Steele Creek Rd",
            "sgreen@email.com",
            "cuffless")
    ];

    public static RouteGroupBuilder MapTrachsEndPoints(this WebApplication app)
    {
        var group =  app.MapGroup("customers")
                        .WithParameterValidation();

        // GET /customers
        group.MapGet("/", () => customers);

        //GET /customers/1
        group.MapGet("/{id}", (int id) => 
        {
            CustomerDto? customer = customers.Find(customer => customer.Id == id);

            return customer is null ? Results.NotFound() : Results.Ok(customer);
        })
            .WithName(GetCustomerEndPointName);

        // POST /customers
        group.MapPost("/", (CreateCustomerDto newCustomer) => 
        {
            CustomerDto customer = new(
                customers.Count + 1,
                newCustomer.FirstName,
                newCustomer.LastName,
                newCustomer.Address,
                newCustomer.Email,
                newCustomer.TrachType);

            customers.Add(customer);

            return Results.CreatedAtRoute(GetCustomerEndPointName, new { id = customer.Id}, customer);
        });

        // PUT /customers
        group.MapPut("/{id}", (int id, UpdateCustomerDto updatedCustomer) => 
        {
            var index = customers.FindIndex(customer => customer.Id == id);

            if (index == -1)
            {
                return Results.NotFound();
            }

            customers[index] = new CustomerDto(
                id,
                updatedCustomer.FirstName,
                updatedCustomer.LastName,
                updatedCustomer.Address,
                updatedCustomer.Email,
                updatedCustomer.TrachType
            );

            return Results.NoContent();
        });

        // DELETE /customers/1
        group.MapDelete("/{id}", (int id) =>
        {
            customers.RemoveAll(customer => customer.Id == id);

            return Results.NoContent();
        });

        return group;
    }
}
