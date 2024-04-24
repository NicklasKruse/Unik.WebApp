using Microsoft.EntityFrameworkCore;
using Shared;
using SqlServerContext;
using Unik.Application.Commands.Member;
using Unik.Application.Commands.Member.Implementation;
using Unik.Application.Queries.Member;
using Unik.Application.Queries.Member.Implementation;
using Unik.Application.Repositories;
using Unik.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add-Migration InitialMigration -Context BackendDbContext -Project SqlServerContext.Migrations
builder.Services.AddDbContext<BackendDbContext>(
    options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("BackendDbConnection"), x => x.MigrationsAssembly("SqlServerContext.Migrations"))); //Hvor vi vil have vores Migrations. Kræver referencen til SqlServerContext.Migrations

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>(p =>
{
    var db = p.GetService<BackendDbContext>(); 
    return new UnitOfWork(db);
});

//Service registrering Members
builder.Services.AddScoped<IMemberRepository, MemberRepository>();
builder.Services.AddScoped<ICreateMemberCommand, CreateMemberCommand>();
builder.Services.AddScoped<IGetAllMemberQuery, GetAllMemberQuery>();
builder.Services.AddScoped<IGetMemberQuery, GetMemberQuery>();
builder.Services.AddScoped<IEditMemberCommand, EditMemberCommand>();
builder.Services.AddScoped<IDeleteMemberCommand, DeleteMemberCommand>();

//Service registrering Booking

//Service registrering Bookings

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
