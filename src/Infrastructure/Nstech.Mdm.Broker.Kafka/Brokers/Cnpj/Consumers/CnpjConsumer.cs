using MassTransit;
using Nstech.Mdm.Domain.Broker.Consumers;
using Nstech.Mdm.Domain.Broker.Consumers.Message;

namespace Nstech.Mdm.Broker.Kafka.Brokers.Cnpj.Consumers
{
    public class CnpjConsumer : IConsumer<CnpjMessage>
    {
        private readonly ICnpjVallidateConsumer _cnpjVallidateConsumer;

        public CnpjConsumer(ICnpjVallidateConsumer cnpjVallidateConsumer)
        {
            _cnpjVallidateConsumer = cnpjVallidateConsumer;
        }

        public Task Consume(ConsumeContext<CnpjMessage> context) => _cnpjVallidateConsumer.IntegrationAsync(context.Message);
    }
}
