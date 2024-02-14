using InternKYCApplication;
using InternKYCApplication.Helpers.Utils;

using InternKYCApplication.Services.UserDetailService;
using InternKYCApplication.Services.UserService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//GlobalAttributes.mysqlConfiguration.connectionString = builder.Configuration.GetConnectionString("MySqlConnection");


// Add Application Db Context

 builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});  


builder.Services.AddScoped<IOtpAuthService, OtpAuthService>();
builder.Services.AddScoped<ICustomerDataService, CustomerDataService>();


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

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthorization();



app.MapControllers();

app.Run();
