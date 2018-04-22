using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agenda.Model
{
    [Table("contatos")]
    class Contato
    {
        [Key]
        public int id { get; set; }

        public string nome { get; set; }

        public string telefone { get; set; }

        public string email { get; set; }
    }
}
