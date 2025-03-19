using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nstech.Mdm.Domain.Options;
using Nstech.Mdm.Repository.Postgresql.Context;

namespace Nstech.Mdm.Repository.Postgresql.Extension
{
    public static class DbContextConfiguration
    {

        public static IServiceCollection ConfigureNstechContext(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<NstechContext>(c => c.UseNpgsql(config.GetConnectionString("Nstech")));
            return services;
        }

    }
}
