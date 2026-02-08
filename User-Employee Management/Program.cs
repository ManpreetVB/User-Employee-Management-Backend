
using User_Employee_Management.BAL;
using User_Employee_Management.DAL;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<UserBAL>();
builder.Services.AddScoped<UserDAL>();
builder.Services.AddControllers();
builder.Services.AddScoped<EmployeeBAL>();
builder.Services.AddScoped<EmployeeDAL>();
builder.Services.AddControllers();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
