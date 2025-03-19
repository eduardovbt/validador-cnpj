using FluentValidation;
using FluentValidation.AspNetCore;
using Nstech.Mdm.DependencyInjector.Configuration;
using Nstech.Mdm.Domain.Options;
using Nstech.Mdm.Domain.Validators;
using Nstech.Mdm.Repository.Postgresql.Extension;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.Configure<CnpjKafkaOption>(builder.Configuration.GetSection("Kafka:CnpjValidate"));
builder.Services.AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .ConfigureNstechContext(builder.Configuration)
    .AddFluentValidationAutoValidation()
    .AddValidatorsFromAssemblyContaining<CnpjValidator>()
    .AddServices()
    .AddRepositories()
    .AddConsumers()
    .AddProducers()
    .AddKafka(builder.Configuration);


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
