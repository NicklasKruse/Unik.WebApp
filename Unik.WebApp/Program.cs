using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Unik.Application.Commands;
using Unik.Application.Commands.Implementation;
using Unik.Application.Repository;
using Unik.Infrastructure.Repositories;
using Unik.WebApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("WebAppUserConnection") ?? throw new InvalidOperationException("Connection string 'WebAppUserConnection' not found.");
builder.Services.AddDbContext<WebAppUserDbContext>(options =>
    options.UseSqlServer(connectionString));
//builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<WebAppUserDbContext>();
builder.Services.AddSwaggerGen();
builder.Services.AddControllersWithViews();

// IOC, ikke glad for det, men det er vores startup og derfor er det også her vi registrerer vores services.
builder.Services.AddScoped<ICreateBookingCommand, CreateBookingCommand>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseMigrationsEndPoint();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
