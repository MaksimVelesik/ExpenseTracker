var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<ExpenseTracker.Services.ExpenseService>();

var app = builder.Build();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Expenses}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "filter",
    pattern: "Expenses/Filter/{category}",
    defaults: new { controller = "Expenses", action = "Filter" });

app.Run();