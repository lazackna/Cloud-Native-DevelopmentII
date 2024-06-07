using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configuration
{
    public class MeasurementConfiguration : IEntityTypeConfiguration<MeasurementData>
    {
        public void Configure(EntityTypeBuilder<MeasurementData> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.AtmosPressure).IsRequired();
            builder.Property(e => e.WindSpeed).IsRequired();
            builder.Property(e => e.Temperature).IsRequired();
            builder.Property(e => e.WindDirection).IsRequired();
            builder.Property(e => e.SeasonId).IsRequired();
        }
    }
}
