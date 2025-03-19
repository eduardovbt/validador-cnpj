using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nstech.Mdm.Abstract.Repository;
using Nstech.Mdm.Abstract.Services.Base;
using Nstech.Mdm.Domain.Entities;

namespace Nstech.Mdm.Abstract.Services
{
    public interface ICnpjService : IBaseService
    {
        Task<IEnumerable<CnpjRecords>> TesteAsync();
        Task AddAsync(CnpjRecords cnpjRecords);
    }
}
