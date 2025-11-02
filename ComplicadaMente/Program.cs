using ComplicadaMente.Components;
using Microsoft.EntityFrameworkCore;
using ComplicadaMente.Components.Data;
using ComplicadaMente.Services;
using ComplicadaMente.StateManagement; // Add this namespace

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


// Register the DbContext with the database connection string
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") + ";TrustServerCertificate=True"));
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<LocalStorageService>();
builder.Services.AddSingleton<ShoppingCartService>();
builder.Services.AddScoped<EncomendaService>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();

//app.MapControllers();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();