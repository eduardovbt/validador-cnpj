using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Nstech.Mdm.Repository.Postgresql.Configuration;

namespace Nstech.Mdm.Repository.Postgresql.Context
{
    public class NstechContext : DbContext
    {
        public NstechContext(DbContextOptions options) : base(options)
        {
           
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
                => optionsBuilder.LogTo(message => Debug.WriteLine(message));
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(NstechContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
