using Agenda.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Agenda.DAO
{
    class ContatoDAO
    {
        private static Context ctx = Singleton.Instance.Context;

        public static bool AdicionarContato(Contato contato)
        {
            try
            {
                ctx.Contatos.Add(contato);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public static bool RemoverContato(Contato contato)
        {
            try
            {
                ctx.Contatos.Remove(contato);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public static bool AlterarContato(Contato c)
        {
            try
            {
                ctx.Entry(c).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return false;
            }
        }
    }
}
