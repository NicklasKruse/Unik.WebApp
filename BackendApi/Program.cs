using Microsoft.EntityFrameworkCore;
using Shared;
using SqlServerContext;
using Unik.Application.Commands.Booking;
using Unik.Application.Commands.Booking.Implementation;
using Unik.Application.Commands.Invitation;
using Unik.Application.Commands.Invitation.Implementation;
using Unik.Application.Commands.Item;
using Unik.Application.Commands.Item.Implementation;
using Unik.Application.Commands.Member;
using Unik.Application.Commands.Member.Implementation;
using Unik.Application.Mappers;
using Unik.Application.Queries.Booking;
using Unik.Application.Queries.Booking.Implementation;
using Unik.Application.Queries.Invitation;
using Unik.Application.Queries.Invitation.Implementation;
using Unik.Application.Queries.Item;
using Unik.Application.Queries.Item.Implementation;
using Unik.Application.Queries.Member;
using Unik.Application.Queries.Member.Implementation;
using Unik.Application.Repositories;
using Unik.Application.Repository;
using Unik.Domain.Ínterfaces;
using Unik.Infrastructure.DomainServices;
using Unik.Infrastructure.Mappers;
using Unik.Infrastructure.Repositories;
using Stripe;
using Unik.Application.Commands.MemberWithAddress;
using Unik.Application.Commands.MemberWithAddress.Implementation;
using Unik.Application.Queries.MemberWithAddress;
using Unik.Application.Queries.MemberWithAddress.Implementation;
using Microsoft.AspNetCore.Identity.UI.Services;
using Unik.Infrastructure.EmailService;
using Unik.Application.ServiceContracts.EmailService;
using Unik.Application.Commands.EmailCommand;

var builder = WebApplication.CreateBuilder(args);

//StripeConfiguration.ApiKey = builder.Configuration["ApiKey"]; //Fra appsettings
StripeConfiguration.ApiKey = "sk_test_51PFxPoRvZK1H133cM0lFy7iFRGHuDehPlIZvQL1U0CpCZiQErkXtcXkajGL5hyaP5JVWJlbxqRg3A90mESvVPuwZ00GdqHF09e"; 


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Hvis container kører vil den forsøge at skabe forbindelse mellem begge projekter. Så db updates kan kun køre uden container.

//Add-Migration InitialMigration -Context BackendDbContext -Project SqlServerContext.Migrations
builder.Services.AddDbContext<BackendDbContext>(
    options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("BackendDbConnection"), x => x.MigrationsAssembly("SqlServerContext.Migrations"))); //Hvor vi vil have vores Migrations. Kræver referencen til SqlServerContext.Migrations

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>(p =>
{
    var db = p.GetService<BackendDbContext>();
    return new UnitOfWork(db);
});



//Scoped fordi vi vil sørge bibeholde "state" i hele requesten. Nogle commands/queries kunne måske være transient, men lader dem være scoped, da de skal interagere med andre scoped services, og derfor skal de have samme "state".

//Service registrering Member
builder.Services.AddScoped<IMemberRepository, MemberRepository>();
builder.Services.AddScoped<ICreateMemberCommand, CreateMemberCommand>();
builder.Services.AddScoped<IGetAllMemberQuery, GetAllMemberQuery>();
builder.Services.AddScoped<IGetMemberQuery, GetMemberQuery>();
builder.Services.AddScoped<IEditMemberCommand, EditMemberCommand>();
builder.Services.AddScoped<IDeleteMemberCommand, DeleteMemberCommand>();

//Service registrering Booking
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<ICreateBookingCommand, CreateBookingCommand>();
builder.Services.AddScoped<IGetAllBookingQuery, GetAllBookingQuery>();
builder.Services.AddScoped<IGetBookingQuery, GetBookingQuery>();
builder.Services.AddScoped<IEditBookingCommand, EditBookingCommand>();
builder.Services.AddScoped<IDeleteBookingCommand, DeleteBookingCommand>();
builder.Services.AddScoped<IBookingDomainService, BookingDomainService>();

//Service registrering Invitation
builder.Services.AddScoped<IInvitationRepository, InvitationRepository>();
builder.Services.AddScoped<ICreateInvitationCommand, CreateInvitationCommand>();
builder.Services.AddScoped<IGetInvitationQuery, GetInvitationQuery>();
builder.Services.AddScoped<IGetAllInvitationQuery, GetAllInvitationQuery>();
builder.Services.AddScoped<IEditInvitationCommand, EditInvitationCommand>();
builder.Services.AddScoped<IDeleteInvitationCommand, DeleteInvitationCommand>();

// Items
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<IGetAllItemQuery, GetAllItemQuery>();
builder.Services.AddScoped<IGetItemQuery, GetItemQuery>();
builder.Services.AddScoped<ICreateItemCommand, CreateItemCommand>();
builder.Services.AddScoped<IEditItemCommand, EditItemCommand>();
builder.Services.AddScoped<IDeleteItemCommand, DeleteItemCommand>();


builder.Services.AddScoped<IMemberWithAddressRepository, MemberWithAddressRepository>();
builder.Services.AddScoped<ICreateMemberWithAddressCommand, CreateMemberWithAddressCommand>();
builder.Services.AddScoped<IGetAllMemberWithAddressQuery, GetAllMemberWithAddressQuery>();
builder.Services.AddScoped<IDeleteMemberWithAddressCommand, DeleteMemberWithAddressCommand>();

builder.Services.AddTransient<Unik.Application.ServiceContracts.EmailService.IEmailSender, EmailSender>(); //Aspnet Identity har sin egen IEmailSender, så vi skal specificere hvilken vi vil bruge her.
builder.Services.AddScoped<ISendEmailCommand, SendEmailCommand>();

builder.Services.AddScoped<IItemMapper, ItemMapper>();

builder.Services.AddScoped<IBookingDomainService, BookingDomainService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
