
using System.Net.Sockets;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Nstech.Mdm.Broker.Kafka.Brokers.Cnpj.Consumers;
using Nstech.Mdm.Domain.Broker.Consumers.Message;
using Nstech.Mdm.Domain.Broker.Producer.Message;
using Nstech.Mdm.Domain.Options;

namespace Nstech.Mdm.DependencyInjector.Configuration
{
    public static class KafkaConfiguration
    {

        public static IServiceCollection AddKafka(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMassTransit(x =>
            {
                x.UsingInMemory();

                x.AddRider(rider =>
               {
                   var build = x.BuildServiceProvider();
                   var option = build.GetService<IOptions<CnpjKafkaOption>>()?.Value;
                   
                   rider.AddConsumer<CnpjConsumer>();
                   rider.AddProducer<CnpjIntegrationErrorMessage>(option.TopicConsumerErroName);
                   rider.AddProducer<CnpjIntegrationSuccessMessage>(option.TopicConsumersuccessName);
                   rider.AddProducer<CnpjIntegrationMessage>(option.TopicConsumerName);
                   rider.UsingKafka((context, k) =>
                    {
                        k.Host($"{option.Host}:{option.Port}");
                        k.TopicEndpoint<CnpjMessage>(option.TopicConsumerName, option.GroupName, e =>
                        {
                            e.ConfigureConsumer<CnpjConsumer>(context);
                        });
                    });
                });


            });
            return services;
        }
    }
}

