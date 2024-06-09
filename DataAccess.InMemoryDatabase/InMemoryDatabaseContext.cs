using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.InMemoryDatabase
{
    /// <summary>
    /// Implementation of the base <see cref="DataContext"/>
    /// This version implements the context with an InMemory provider.
    /// </summary>
    public class InMemoryDataContext : DataContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString());
            base.OnConfiguring(optionsBuilder);
        }
    }
}
