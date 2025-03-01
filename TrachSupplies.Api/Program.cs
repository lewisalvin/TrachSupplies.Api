using TrachSupplies.Api.Data;
using TrachSupplies.Api.Endpoints;

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("TrachSupplies");
builder.Services.AddSqlite<TrachSuppliesContext>(connString);


var app = builder.Build();

app.MapTrachsEndPoints();

app.Run();
