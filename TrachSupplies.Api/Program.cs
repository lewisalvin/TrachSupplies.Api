using TrachSupplies.Api.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

const string GetCustomerEndPointName = "GetCustomer";

List<CustomerDto> customers = [
    new(
        1,
        "Braxton",
        "Lewis",
        "1111 Wooden Snow Lane",
        "chasitysheri@gmail.com"),
    new(
        2,
        "Matteo",
        "Garcia",
        "2222 Capps Rd",
        "galgathg@email.com"),
    new(
        3,
        "Nikko",
        "Green",
        "3333 Steele Creek Rd",
        "sgreen@email.com")
];

// GET /customers
app.MapGet("customers", () => customers);

//GET /customers/1
app.MapGet("customers/{id}", (int id) => 
{
    CustomerDto? customer = customers.Find(customer => customer.Id == id);

    return customer is null ? Results.NotFound() : Results.Ok(customer);
})
    .WithName(GetCustomerEndPointName);

// POST /customers
app.MapPost("customers", (CreateCustomerDto newCustomer) => 
{
    CustomerDto customer = new(
        customers.Count + 1,
        newCustomer.firstName,
        newCustomer.lastName,
        newCustomer.address,
        newCustomer.email);

    customers.Add(customer);

    return Results.CreatedAtRoute(GetCustomerEndPointName, new { id = customer.Id}, customer);
});

// PUT /customers
app.MapPut("customers/{id}", (int id, UpdateCustomerDto updatedCustomer) => 
{
    var index = customers.FindIndex(customer => customer.Id == id);

    if (index == -1)
    {
        return Results.NotFound();
    }

    customers[index] = new CustomerDto(
        id,
        updatedCustomer.firstName,
        updatedCustomer.lastName,
        updatedCustomer.address,
        updatedCustomer.email
    );

    return Results.NoContent();
});

// DELETE /customers/1
app.MapDelete("customers/{id}", (int id) =>
{
    customers.RemoveAll(customer => customer.Id == id);

    return Results.NoContent();
});

app.Run();
