using System.Reflection;
using Microsoft.EntityFrameworkCore;
using MyContacts.Components;
using MyContacts.Data;
using MyContacts.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<ContactService>();
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddDbContext<ContactDbContext>(options =>
{
    options.UseSqlite(
        builder.Configuration.GetConnectionString("ContactsDb"));
});

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();