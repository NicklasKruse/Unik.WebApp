using FrontConnectLibrary.Interfaces; //har project reference to library nu
using FrontConnectLibrary.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebAppUserContext;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("WebAppUserConnection") ?? throw new InvalidOperationException("Connection string 'WebAppUserConnection' not found.");

//Add-Migration InitialMigration -Context WebAppUserDbContext -Project WebAppUserContext.Migrations
builder.Services.AddDbContext<WebAppUserDbContext>(options =>
    options.UseSqlServer(connectionString, x => x.MigrationsAssembly("WebAppUserContext.Migrations")));
//builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<WebAppUserDbContext>();


builder.Services.AddSwaggerGen();
builder.Services.AddRazorPages();


builder.Services.AddHttpClient<IMemberService, MemberService>(
    client => client.BaseAddress = new Uri(builder.Configuration["BasisUrl"]));  //Denne BasisUrl skal være den samme som i Launchsettings i BackendApi




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
