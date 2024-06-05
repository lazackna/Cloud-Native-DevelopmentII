using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcess;

namespace DataAcess.SqlLite
{
    public static class Setup
    {
        public static IServiceCollection SetupDataAccessSqlLite(this IServiceCollection services)
        {
            return services
                .AddDbContext<DataContext, SqlLiteDataContext>();
        }
    }
}
