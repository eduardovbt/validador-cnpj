using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nstech.Mdm.Abstract.Repository;
using Nstech.Mdm.Abstract.Services;
using Nstech.Mdm.Domain.Entities;

namespace Nstech.Mdm.Domain.Services
{
    public class CnpjService : ICnpjService
    {
        private readonly ICnpjRecordsRepository _cnpjRecordsRepository;

        public CnpjService(ICnpjRecordsRepository cnpjRecordsRepository)
        {
            _cnpjRecordsRepository = cnpjRecordsRepository;
        }

        public Task AddAsync (CnpjRecords cnpjRecords) => _cnpjRecordsRepository.AddAsync (cnpjRecords);
        public Task<IEnumerable<CnpjRecords>> TesteAsync() => _cnpjRecordsRepository.GetAllAsync();
    }
}
