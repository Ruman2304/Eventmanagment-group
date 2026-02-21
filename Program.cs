using Microsoft.EntityFrameworkCore;
using EventManagement.Api.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Use ONE DbContext + ONE provider (SQLite)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<EventManagement.Api.Repositories.IEventRepository, EventManagement.Api.Repositories.EventRepository>();
builder.Services.AddScoped<EventManagement.Api.Services.IEventService, EventManagement.Api.Services.EventService>();
builder.Services.AddScoped<EventManagement.Api.Repositories.IUserRepository, EventManagement.Api.Repositories.UserRepository>();
builder.Services.AddScoped<EventManagement.Api.Services.IUserService, EventManagement.Api.Services.UserService>();
builder.Services.AddScoped<EventManagement.Api.Repositories.IRegistrationRepository, EventManagement.Api.Repositories.RegistrationRepository>();
builder.Services.AddScoped<EventManagement.Api.Services.IRegistrationService, EventManagement.Api.Services.RegistrationService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.MapControllers();
app.Run();