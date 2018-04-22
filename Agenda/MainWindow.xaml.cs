using Agenda.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Agenda
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        private Contato cc;
        private string operacao;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {
            cc = new Contato
            {
                nome = txtNome.Text,
                telefone = txtTelefone.Text,
                email = txtEmail.Text
          
            };
            // contato com os dados da tela
            contato c = new contato();
            c.nome = txtNome.Text;
            c.email = txtEmail.Text;
            c.telefone = txtTelefone.Text;
            // gravar no banco
            if (operacao == "inserir")
            {
                using (agendaEntities ctx = new agendaEntities())
                {
                    ctx.contatos.Add(c);
                    ctx.SaveChanges();
                }
            }
            if (operacao == "alterar")
            {

            }
            this.ListarContatos();
            this.AlteraBotoes(1);
            this.LimpaCampos();
        }
        private void LimpaCampos()
        {
            txtID.IsEnabled = true;
            txtID.Clear();
            txtNome.Clear();
            txtEmail.Clear();
            txtTelefone.Clear();
        }

        private void btInserir_Click(object sender, RoutedEventArgs e)
        {
            this.operacao = "inserir";
            this.AlteraBotoes(2);
            txtID.Text = "";
            txtID.IsEnabled = false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.ListarContatos();
            this.AlteraBotoes(1);   
        }

        private void ListarContatos()
        {
            using (agendaEntities ctx = new agendaEntities())
            {
                int a = ctx.contatos.Count();
                lbQtdContatos.Content = "Número de contatos existente: " + a.ToString();
                var consulta = ctx.contatos;
                dgDados.ItemsSource = consulta.ToList();
            }
        }

        private void AlteraBotoes(int op)
        {
            btAlterar.IsEnabled = false;
            btInserir.IsEnabled = false;
            btExcluir.IsEnabled = false;
            btCancelar.IsEnabled = false;
            btLocalizar.IsEnabled = false;
            btSalvar.IsEnabled = false;

            if (op == 1)
            { // ativar as opcoes iniciais
                btInserir.IsEnabled = true;
                btLocalizar.IsEnabled = true;
            }
            if (op == 2)
            { // inserir um valor
                btCancelar.IsEnabled = true;
                btSalvar.IsEnabled = true;
            }
            if (op == 3)
            {
                btAlterar.IsEnabled = true;
                btExcluir.IsEnabled = true;
            }
        }

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.AlteraBotoes(1);
            this.LimpaCampos();
        }

        private void btLocalizar_Click(object sender, RoutedEventArgs e)
        {
            // buscar pelo id
            if (txtID.Text.Trim().Count() > 0)
            {
                try
                {
                    int id = Convert.ToInt32(txtID.Text);
                    using (agendaEntities ctx = new agendaEntities())
                    {
                        contato c = ctx.contatos.Find(id);
                        dgDados.ItemsSource = new contato[1] { c };
                    }
                } catch
                {

                }
            }
            // buscar pelo nome
            if (txtNome.Text.Trim().Count() > 0)
            {
               try
                {
                    using (agendaEntities ctx = new agendaEntities())
                    {
                        var consulta = from c in ctx.contatos
                                       where c.nome.Contains(txtNome.Text)
                                       select c;
                        dgDados.ItemsSource = consulta.ToList();
                    }
                } catch
                {

                }
            }
            // buscar pelo email
            if (txtEmail.Text.Trim().Count() > 0)
            {
                try
                {
                    using (agendaEntities ctx = new agendaEntities())
                    {
                        var consulta = from c in ctx.contatos
                                       where c.email.Contains(txtEmail.Text)
                                       select c;
                        dgDados.ItemsSource = consulta.ToList();
                    }
                }
                catch
                {

                }
            }
            // buscar pelo telefone
            if (txtTelefone.Text.Trim().Count() > 0)
            {
                try
                {
                    using (agendaEntities ctx = new agendaEntities())
                    {
                        var consulta = from c in ctx.contatos
                                       where c.telefone.Contains(txtTelefone.Text)
                                       select c;
                        dgDados.ItemsSource = consulta.ToList();
                    }
                }
                catch
                {

                }
            }
        }

        private void dgDados_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
