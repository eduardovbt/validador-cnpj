using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nstech.Mdm.Domain.Entities;

namespace Nstech.Mdm.Repository.Postgresql.Configuration
{
    public class CnpjRecordsConfiguration  : IEntityTypeConfiguration<CnpjRecords>
    {
        public void Configure(EntityTypeBuilder<CnpjRecords> builder)
        {
            builder.ToTable("cnpj_records");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("id");
            builder.Property(p => p.Cnpj).HasColumnName("cnpj"); 
            builder.Property(p => p.CreateAt).HasColumnName("create_at");
        }
    }
}
