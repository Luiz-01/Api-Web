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
    public class config_usu_usuario : IEntityTypeConfiguration<tb_usu_usuario>
    {
        public void Configure(EntityTypeBuilder<tb_usu_usuario> builder)
        {
            builder.HasKey(x => x.usu_n_codigo);
            builder.Property(x => x.usu_n_codigo).IsRequired(true).HasColumnType("newsequentialid()");

            builder.Property(x => x.usu_c_usuario).IsRequired(true).HasColumnType("varchar(50)");
            builder.Property(x => x.usu_c_senha).IsRequired(true).HasColumnType("varchar(50)");
        }
    }
}
