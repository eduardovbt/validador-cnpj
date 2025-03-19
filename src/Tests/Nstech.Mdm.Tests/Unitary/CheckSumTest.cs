using Nstech.Mdm.Domain.Rules;
using FluentAssertions;
using Nstech.Mdm.Domain.Broker.Consumers.Message;
using Nstech.Mdm.Domain.Validators;
using Nstech.Mdm.Tests.Rules;

namespace Nstech.Mdm.Tests.Unitary
{
    public class CheckSumTest
    {
        private CnpjMessageFakeGenerator FakeGenerator = new CnpjMessageFakeGenerator();

        [Theory]
        [MemberData(nameof(Data))]
        public void Cpnj_Must_Expected_Value(CnpjMessage message, bool resultExpected)
        {
            var result = CheckSumRule.CnpjIsValid(message.Cnpj);
            result.Should().Be(resultExpected);
        }

        [Fact]
        public void Cpnj_Must_Valid()
        {
            var cnpj =  CnpjValidRule.GerarCnpjValido();
            var fake = FakeGenerator.GenerateFakeCnpjMessage();
            var result = CheckSumRule.CnpjIsValid(fake.Cnpj);

            result.Should().BeTrue();
        }

        [Fact]
        public void Cpnj_Must_Invalid()
        {
            var fake = FakeGenerator.GenerateFakeCnpjMessageInvalid();
            var result = CheckSumRule.CnpjIsValid(fake.Cnpj);

            result.Should().BeFalse();
        }

        public static IEnumerable<object[]> Data =>
          new List<object[]>
          {
                    new object[] { FakeStatic(false), false},
                    new object[] { FakeStatic(false), false},
                    new object[] { FakeStatic(true), true},
                    new object[] { FakeStatic(true), true},
                    new object[] { FakeStatic(true), true},
          };
        private static CnpjMessage FakeStatic(bool cnpjIsValid) => cnpjIsValid ? new CnpjMessageFakeGenerator().GenerateFakeCnpjMessage() : new CnpjMessageFakeGenerator().GenerateFakeCnpjMessageInvalid();
    }
}