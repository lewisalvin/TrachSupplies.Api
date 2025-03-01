using TrachSupplies.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapTrachsEndPoints();

app.Run();
