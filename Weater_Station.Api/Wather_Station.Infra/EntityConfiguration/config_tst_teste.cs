using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather_Station.Domain.Entities;

namespace Weather_Station.Infra.EntityConfiguration
{
    public class config_tst_teste : IEntityTypeConfiguration<tb_tst_teste>
    {
        public void Configure(EntityTypeBuilder<tb_tst_teste> builder)
        {
            builder.HasKey(x => x.tst_n_codigo);
            builder.Property(x => x.tst_n_codigo).IsRequired(true).HasColumnType("newsequentialid()");

            builder.Property(x => x.tst_c_teste).IsRequired(true).HasColumnType("varchar(50)");
        }
    }
}
