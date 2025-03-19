using Bogus;
using Nstech.Mdm.Domain.Broker.Consumers.Message;
using Nstech.Mdm.Tests.Rules;

public class CnpjMessageFakeGenerator
{
    public CnpjMessage GenerateFakeCnpjMessageInvalid()
    {
        var faker = new Faker<CnpjMessage>()
            .RuleFor(c => c.Cnpj, f => f.Random.Replace("##.###.###/####-##"));
        return faker.Generate();
    }

    public CnpjMessage GenerateFakeCnpjMessage()
    {
        var faker = new Faker<CnpjMessage>()
            .RuleFor(c => c.Cnpj, f => CnpjValidRule.GerarCnpjValido());
        return faker.Generate();

    } 
}



