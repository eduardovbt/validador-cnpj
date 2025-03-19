using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nstech.Mdm.Domain.Broker.Producer.Message
{
    public class CnpjIntegrationErrorMessage
    {
        public string Cnpj { get; set; }
        public DateTime IntegrationDate { get; set; }
        public string Error { get; set; }
    }
}
