using Agenda.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.DAO
{
    class Context : DbContext
        {
            public DbSet<Contato> Contatos { get; set; }
        }
}
