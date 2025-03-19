using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nstech.Mdm.Domain.Entities
{
    public class CnpjRecords
    {
        public Guid Id { get; set; }    
        public string Cnpj { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
