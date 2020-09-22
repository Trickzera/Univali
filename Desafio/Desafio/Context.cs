using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Common;

namespace Desafio
{
    class Context : DbContext
    {
        public DbSet<Fornecedor> fornecedores { get; set; }
        public Context() : base("sistemaFuncionarioDBConnectionString")
        {
            Database.SetInitializer<Context>(new CreateDatabaseIfNotExists<Context>());
            Database.Initialize(true);
            Database.CreateIfNotExists();
        }
        protected override void OnModelCrating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fornecedor>().ToTable("Fornecedores");
            base.OnModelCreating(modelBuilder);
        }
    }
        
   
}
