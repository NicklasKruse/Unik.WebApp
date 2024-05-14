using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebAppFront.Services.Implementation;
using WebAppFront.Services.Interfaces;
using WebAppFront.Services.Services;
using WebAppUserContext;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("WebAppUserConnection") ?? throw new InvalidOperationException("Connection string 'WebAppUserConnection' not found.");

//docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=nikr54684!" --name uniksqlserver -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest

//Add-Migration InitialMigration -Context WebAppUserDbContext -Project WebAppUserContext.Migrations
builder.Services.AddDbContext<WebAppUserDbContext>(options =>
    options.UseSqlServer(connectionString, x => x.MigrationsAssembly("WebAppUserContext.Migrations")));
//builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    //Password
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;

    // hvor mange forsøg har man osv.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    // Sikrer at man har en unik email
    options.User.RequireUniqueEmail = true;
})
    .AddRoles<IdentityRole>()
.AddEntityFrameworkStores<WebAppUserDbContext>();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Formand", policy =>
        policy.RequireRole("Formand"));

    options.AddPolicy("Bestyrelse", policy =>
        policy.RequireRole("Bestyrelse"));

    options.AddPolicy("Medlem", policy =>
        policy.RequireRole("Medlem"));

    options.AddPolicy("Admin", policyBuilder => policyBuilder.RequireClaim("Admin"));
});


builder.Services.AddScoped<IFileUploadService, FileUploadService>();
builder.Services.AddScoped<IGetContentType, GetContentType>();

builder.Services.AddSwaggerGen();

builder.Services.AddRazorPages(options =>
{
    //sikre at man skal være logged in for at kunne tilgå mapper. 
    options.Conventions.AuthorizeFolder("/Users");
    options.Conventions.AuthorizeFolder("/Item");
    options.Conventions.AuthorizeFolder("/Booking");
    options.Conventions.AuthorizeFolder("/Invitations");
    options.Conventions.AuthorizeFolder("/Member");
    options.Conventions.AuthorizeFolder("/UploadFile");
    options.Conventions.AuthorizeFolder("/ListFiles");
    options.Conventions.AuthorizeFolder("/Documents");
    options.Conventions.AuthorizeFolder("/Messages");
});


builder.Services.AddHttpClient<IMemberService, MemberService>(
    client => client.BaseAddress = new Uri(builder.Configuration["BasisUrl"]));  //Denne BasisUrl skal være den samme som i Launchsettings i BackendApi eller stemme overens med docker compose 

builder.Services.AddHttpClient<IItemService, ItemService>(
       client => client.BaseAddress = new Uri(builder.Configuration["BasisUrl"]));

builder.Services.AddHttpClient<IBookingService, BookingService>(
    client => client.BaseAddress = new Uri(builder.Configuration["BasisUrl"]));

builder.Services.AddHttpClient<IInvitationService, InvitationService>(client => client.BaseAddress = new Uri(builder.Configuration["BasisUrl"]));

builder.Services.AddHttpClient<IAddressService, AddressService>(client => client.BaseAddress = new Uri(builder.Configuration["BasisUrl"]));




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
