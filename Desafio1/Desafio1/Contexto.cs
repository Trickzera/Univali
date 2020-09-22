using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio1
{
    public class Contexto : DbContext
    {
        public DbSet<Usuário> Usuário { get; set; }
    }
}
