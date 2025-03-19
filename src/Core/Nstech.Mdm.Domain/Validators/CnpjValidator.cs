using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Nstech.Mdm.Domain.Broker.Consumers.Message;

namespace Nstech.Mdm.Domain.Validators
{
    public class CnpjValidator : AbstractValidator<CnpjMessage>
    {
        public CnpjValidator()
        {
            RuleFor(x => x.Cnpj)
                .NotEmpty().WithMessage(Resources.CnpjResource.CnpjIsNotNull)
                .Matches(@"^\d{14}$").WithMessage(Resources.CnpjResource.CnpjMust14Character)
                .Must(Rules.CheckSumRule.CnpjIsValid).WithMessage(Resources.CnpjResource.CnpjInvalid);
        }
    }
}