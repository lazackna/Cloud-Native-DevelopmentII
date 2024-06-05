using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.SqlLite
{
    public class SqlLiteDataContext : DataContext
    {
        private string _dbPath { get; }

        public SqlLiteDataContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            _dbPath = Path.Join(path, "WeatherDatabase.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={_dbPath}");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
