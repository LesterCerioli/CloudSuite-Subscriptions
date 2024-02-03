using AutoMapper;
using CloudSuite.Infrastructure.Context;
using CloudSuite.Infrastructure.CrossCutting.DependencyInjector;
using CloudSuite.Infrastructure.CrossCutting.HealthChecks;
using CloudSuite.Infrastructure.CrossCutting.Middlewares;
using CloudSuite.Infrastructure.Repositories;
using CloudSuite.Modules.Application.Services.Contracts;
using CloudSuite.Modules.Application.Services.Implementations;
using CloudSuite.Modules.Domain.Contracts;
using CloudSuite.Modules.Domain.Models;
using CloudSuite.Services.Subscriptions.API.Configurations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<SubscriptionDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("AZURE_SQL_CONECTIONSTRING")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediator();
builder.Services.AddLogger();
builder.Services.AddHealthCheckConfigurations();
builder.Services.AddSwaggerDocVersion();
builder.Services.AddTransient<ExceptionHandlingMiddleware>();
builder.Services.AddDatabaseConfiguration(builder.Configuration);

var configuration = new MapperConfiguration(cfg =>
{
});

builder.Services.AddTransient<ICompanyAppService, CompanyAppService>();
builder.Services.AddTransient<ICustomerAppService, CustomerAppService>();
builder.Services.AddTransient<IDomainAppService, DomainAppService>();
builder.Services.AddTransient<IPaymentAppService, PaymentAppService>();
builder.Services.AddTransient<ISubscriptionAppService, SubscriptionAppService>();
builder.Services.AddSingleton<IMapper>(configuration.CreateMapper());
builder.Services.AddTransient<ICompanyRepository, CompanyRepository>();
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
builder.Services.AddTransient<IDomainRepository, DomainRepository>();
builder.Services.AddTransient<IPaymentRepository, PaymentRepository>();
builder.Services.AddTransient<ISubscriptionRepository, SubscriptionRepository>();

builder.Services.AddCors(options =>
{
	options.AddPolicy("my-cors",
						  policy =>
						  {
							  policy
							  .AllowAnyOrigin()
							  .AllowAnyHeader()
							  .AllowAnyMethod();
						  });
});
var app = builder.Build();


if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
	app.UseHttpLogging();
}
//app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseCors("my-cors");

app.Run();
