using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nstech.Mdm.Domain.Broker.Consumers.Message;

namespace Nstech.Mdm.Domain.Broker.Consumers
{
    public interface ICnpjVallidateConsumer
    {
        Task IntegrationAsync(CnpjMessage message);
    }
}
