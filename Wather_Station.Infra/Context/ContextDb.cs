using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather_Station.Domain.Entities;
using Weather_Station.Infra.EntityConfiguration;

namespace Weather_Station.Infra.Context
{
    public class ContextDb : DbContext
    {
        public IConfigurationRoot Configuration { get; set; }

        public ContextDb (DbContextOptions<ContextDb> options) : base (options = new DbContextOptions<ContextDb>())
        {
            Database.EnsureCreated();
            Database.SetCommandTimeout(200);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) 
            {
                optionsBuilder.UseSqlServer(RetornaUrlConexao());
            }
        }

        public string RetornaUrlConexao()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            Configuration = builder.Build();
            string conexao = Configuration.GetConnectionString("cn");
            return conexao;
        }

        public DbSet<tb_tst_teste> tb_Tst_Testes { get; set; }
        public DbSet<tb_usu_usuario> tb_Usu_Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<tb_tst_teste>(new config_tst_teste());
            modelBuilder.ApplyConfiguration<tb_usu_usuario>(new config_usu_usuario());
        }
    }
}
