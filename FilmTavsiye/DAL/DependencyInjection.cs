using DAL.Abrtract;
using DAL.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class DependencyInjection
    {
        public static void DALDependencies(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
            });
        }
    }
}
