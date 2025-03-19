using FluentValidation;
using MassTransit;
using Nstech.Mdm.Abstract.Services;
using Nstech.Mdm.Broker.Kafka.Brokers.Cnpj.Producers;
using Nstech.Mdm.Domain.Broker.Consumers;
using Nstech.Mdm.Domain.Broker.Consumers.Message;
using Nstech.Mdm.Domain.Broker.Producer;
using Nstech.Mdm.Domain.Broker.Producer.Message;
using Nstech.Mdm.Domain.Entities;
using Nstech.Mdm.Domain.Rules;
using Nstech.Mdm.Domain.Validators;

namespace Nstech.Mdm.Broker.Kafka.Brokers.Cnpj.Consumers
{
    public class CnpjValidateConsumer : ICnpjVallidateConsumer
    {
        private readonly IValidator<CnpjMessage> _checkSumValidator;
        private readonly ICnpjService _cnpjService;
        public readonly IProducerBase _producerBase;
        public CnpjValidateConsumer(IValidator<CnpjMessage> checkSumValidator, ICnpjService cnpjService, IProducerBase producerBase)
        {
            _checkSumValidator = checkSumValidator;
            _cnpjService = cnpjService;
            _producerBase = producerBase;
        }



        public async Task IntegrationAsync(CnpjMessage message)
        {
            var resultValidate = _checkSumValidator.Validate(message);
            if (!resultValidate.IsValid)
            {
                await _producerBase.ProduceAsync(new CnpjIntegrationErrorMessage
                {
                    IntegrationDate = DateTime.Now.ToUniversalTime(),
                    Cnpj = message.Cnpj,
                    Error = string.Join(",", resultValidate.Errors)
                });
                return;
            }

            var cnpjRecord = new CnpjRecords
            {
                Id = new Guid(),
                Cnpj = message.Cnpj,
                CreateAt = DateTime.Now.ToUniversalTime()
            };
            await _cnpjService.AddAsync(cnpjRecord);
            await _producerBase.ProduceAsync(new CnpjIntegrationSuccessMessage
            {
                IntegrationDate = DateTime.Now.ToUniversalTime(),
                Cnpj = message.Cnpj
            });

        }
    }
}
