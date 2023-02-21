using BlazorContacts.Data;
using BlazorContacts.Hubs;
using BlazorContacts.Models;
using BlazorContacts.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSignalR();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddDbContextFactory<DatabaseContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString")));

builder.Services.AddTransient<IContactService, ContactService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapHub<ContactHub>("/ContactHub");
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
