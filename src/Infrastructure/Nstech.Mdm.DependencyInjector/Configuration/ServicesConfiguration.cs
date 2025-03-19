using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nstech.Mdm.Abstract.Repository.Base;
using Nstech.Mdm.Abstract.Services.Base;
using Nstech.Mdm.Broker.Kafka.Brokers.Cnpj.Consumers;
using Nstech.Mdm.Broker.Kafka.Brokers.Cnpj.Producers;
using Nstech.Mdm.Domain.Broker.Consumers;
using Nstech.Mdm.Domain.Broker.Producer;
using Nstech.Mdm.Repository.Postgresql.Context;

namespace Nstech.Mdm.DependencyInjector.Configuration
{
    public static class ServicesConfiguration
    {
        private const string Nstech = "Nstech.";
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.Scan(scan => scan.FromApplicationDependencies(r => r.FullName.StartsWith(Nstech))
                                      .AddClasses(classes => classes.AssignableToAny(typeof(IBaseService)))
                                      .AsImplementedInterfaces()
                                      .WithScopedLifetime());
                                       
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.Scan(scan => scan.FromApplicationDependencies(r => r.FullName.StartsWith(Nstech))
                                                .AddClasses(classes => classes.AssignableToAny(typeof(IBaseRepostirory<>)))
                                      .AsImplementedInterfaces()
                                      .WithScopedLifetime());
            return services;
        }

        public static IServiceCollection AddConsumers(this IServiceCollection services)
        {
            services.AddScoped<ICnpjVallidateConsumer,CnpjValidateConsumer>();
            services.AddScoped<CnpjConsumer>();
            return services;
        }
        public static IServiceCollection AddProducers(this IServiceCollection services)
        {
            services.AddScoped<IProducerBase, ProducerBase>();
            return services;
        }
    }
}
