using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Nstech.Mdm.Abstract.Repository;
using Nstech.Mdm.Domain.Entities;
using Nstech.Mdm.Repository.Postgresql.Context;
using Nstech.Mdm.Repository.Postgresql.Repository.Base;

namespace Nstech.Mdm.Repository.Postgresql.Repository
{
    public class CnpjRecordRepository : BaseRepository<CnpjRecords>, ICnpjRecordsRepository
    {
        public CnpjRecordRepository(NstechContext context) : base(context)
        {
        }
    }
}
