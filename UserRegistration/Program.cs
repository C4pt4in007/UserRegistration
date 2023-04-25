using MySql.Data.MySqlClient;
using UserRegistration.Repositiory.AddUserRepository;
using UserRegistration.Repositiory.CheckUserRepository;
using UserRegistration.Service.CheckUserService;
using UserRegistration.Service.EmailValidationService;
using UserRegistration.Service.UserRegistrationService;
using UserRegistration.UserDAO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IUserRegistrationService, UserRegistrationService>();
builder.Services.AddScoped<IEmailValidationService, EmailValidationService>();
builder.Services.AddScoped<ICheckUserService, CheckUserService>();
builder.Services.AddScoped<ICheckUserRepository, CheckUserRepository>();
builder.Services.AddScoped<IMySQLConnection, MySQLConnection>();
builder.Services.AddScoped<IAddUserRepository, AddUserRepository>();

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
