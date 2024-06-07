using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.SqlLite
{
    /// <summary>
    /// See <see cref="SetupDataAccessSqlLite(IServiceCollection)"/>
    /// </summary>
    public static class Setup
    {
        /// <summary>
        /// Registers the SQLite implementation for the <see cref="DataContext"/>
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection SetupDataAccessSqlLite(this IServiceCollection services)
        {
            return services
                .AddDbContext<DataContext, SqlLiteDataContext>();
        }
    }
}
