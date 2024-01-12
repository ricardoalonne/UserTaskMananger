using Microsoft.EntityFrameworkCore;
using UserTaskMananger.Context;
using UserTaskMananger.Service.Implementation;
using UserTaskMananger.Service.Structure;
using UserTaskMananger.UnitOfWork.Implementation;
using UserTaskMananger.UnitOfWork.Structure;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddCors(options =>
{
    options.AddPolicy("AppUserTestMananger", builder =>
    {
        builder.WithOrigins("http://localhost:4555")
                .AllowAnyHeader()
                .AllowAnyMethod();
    }
        );
}
);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddDbContext<UserTaskManangerDbContext>(options
    => options.UseSqlServer(connectionString, build =>
                            build.MigrationsAssembly(typeof(UserTaskManangerDbContext).Assembly.FullName)
    ));

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IPriorityService, PriorityService>();
builder.Services.AddTransient<IUserTaskService, UserTaskService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AppUserTestMananger");

app.UseAuthorization();

app.MapControllers();

app.Run();
