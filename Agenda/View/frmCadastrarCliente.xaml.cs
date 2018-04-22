using Agenda.DAO;
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
using System.Windows.Shapes;

namespace Agenda.View
{
    /// <summary>
    /// Lógica interna para frmCadastrarCliente.xaml
    /// </summary>
    public partial class frmCadastrarCliente : Window
    {
        private static Context ctx = Singleton.Instance.Context;
        private Contato c;
        public frmCadastrarCliente()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.ListarContatos();
        }

        private void ListarContatos()
        {
            var consulta = ctx.Contatos;
            dgDados.ItemsSource = consulta.ToList();
        }

        public void btnGravar_Click(object sender, RoutedEventArgs e)
        {
            c = new Contato
            {
                nome = txtNome.Text,
                telefone = txtTelefone.Text,
                email = txtEmail.Text
            };

            if (ContatoDAO.AdicionarContato(c))
            {
                MessageBox.Show("Contato adicionado com sucesso!", "Agenda",
                MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Não foi possivel adicionar o contato!", "Agenda",
                MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnRemover_Click(object sender, RoutedEventArgs e)
        {
            c = new Contato
            {
                nome = txtNome.Text,
                telefone = txtTelefone.Text,
                email = txtEmail.Text
            };
            if (ContatoDAO.RemoverContato(c))
            {
                MessageBox.Show("Contato removido com sucesso!", "Agenda",
                MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void btnLocalizar_Click(object sender, RoutedEventArgs e)
        {
            // buscar pelo nome
            if (txtNome.Text.Trim().Count() > 0)
            {
                try
                {
                    var consulta = from c in ctx.Contatos
                                   where c.nome.Contains(txtNome.Text)
                                   select c;
                    dgDados.ItemsSource = consulta.ToList();
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
                    var consulta = from c in ctx.Contatos
                                   where c.telefone.Contains(txtTelefone.Text)
                                   select c;
                        dgDados.ItemsSource = consulta.ToList();
                }
                catch
                {

                }
            }
            // buscar pelo email
            if (txtEmail.Text.Trim().Count() > 0)
            {
                try
                {
                    var consulta = from c in ctx.Contatos
                                   where c.email.Contains(txtEmail.Text)
                                   select c;
                        dgDados.ItemsSource = consulta.ToList();
                    }
                catch
                {

                }
            }

        }

        private void btnAlterar_Click(object sender, RoutedEventArgs e)
        {
            c.nome = txtNome.Text;
            c.telefone = txtTelefone.Text;
            c.email = txtEmail.Text;

            if (ContatoDAO.AlterarContato(c))
            {
                MessageBox.Show("Contato alterado com sucesso!", "Agenda",
                MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Não foi possivel alterar o Contato!", "Agenda",
                MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
