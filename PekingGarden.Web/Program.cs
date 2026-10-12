using PekingGarden.DAL;
using PekingGarden.Logic.Interfaces;
using PekingGarden.Logic.Services;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("PekingGarden")
                          ?? throw new InvalidOperationException("Connection string 'PekingGarden' is missing. Set it with dotnet user-secrets.");

builder.Services.AddScoped<ITableRepository>(provider => new TableRepository(connectionString));
builder.Services.AddScoped<IOrderRepository>(provider => new OrderRepository(connectionString));

builder.Services.AddScoped<TableService>();

builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.MapStaticAssets();
app.MapRazorPages()
    .WithStaticAssets();

app.Run();