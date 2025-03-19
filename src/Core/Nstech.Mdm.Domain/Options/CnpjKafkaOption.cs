using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nstech.Mdm.Domain.Options
{
    public class CnpjKafkaOption
    {
        public string Host { get; set; }
        public string Port { get; set; }
        public string GroupName { get; set; }
        public string TopicConsumerName { get; set; }
        public string TopicConsumerErroName { get; set; }
        public string TopicConsumersuccessName { get; set; }
    }
}
