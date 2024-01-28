using CloudSuite.Infrastructure.Context;
using CloudSuite.Infrastructure.Repositories;
using CloudSuite.Modules.Application.Jobs;
using CloudSuite.Modules.Application.Services.Contracts;
using CloudSuite.Modules.Application.Services.Implementations;
using CloudSuite.Modules.Domain.Contracts;
using CloudSuite.Modules.Domain.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHostedService<SubscriptionWorkService>();
//builder.Services.AddHostedService<CompanyWorkService>();
//builder.Services.AddHostedService<CustomerWorkService>();
//builder.Services.AddHostedService<DomainWorkService>();
//builder.Services.AddHostedService<PaymentWorkService>();

builder.Services.AddScoped(typeof(SubscriptionDbContext), typeof(SubscriptionDbContext));
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IDomainRepository, DomainRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();

builder.Services.AddScoped(typeof(CustomerAppService), typeof(ICustomerAppService));
builder.Services.AddScoped(typeof(CompanyAppService), typeof(ICompanyAppService));
builder.Services.AddScoped(typeof(DomainAppService), typeof(IDomainAppService));
builder.Services.AddScoped(typeof(PaymentAppService), typeof(IPaymentAppService));
builder.Services.AddScoped(typeof(SubscriptionAppService), typeof(ISubscriptionAppService));
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
