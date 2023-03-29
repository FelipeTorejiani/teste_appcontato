using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using WPF_ProjetoPDS.RegraDeNegocio;


namespace WPF_ProjetoPDS.Formulario
{ 
/// <summary>
/// Lógica interna para CadastrarContato.xaml
/// </summary>
    public partial class CadastrarContato : Window
    {
        private MySqlConnection _conexao;
        

        public CadastrarContato()
        {
            InitializeComponent();
            Conexao();
        
        }
        private void Conexao()
        {
             string conexaoString = "server=localhos;database=app_contato_bd;user=root;password==root;port=3360";
            _conexao = new MySqlConnection(conexaoString);
            _conexao.Open();
            
        }

        private void btCancelar_Click(object sender, RoutedEventArgs e)
        {
            tbEmail.IsEnabled = false;
            tbSexo.IsEnabled = false;
            tbNome.IsEnabled = false;
            tbTelefone.IsEnabled = false;
          
        }

        private void btSalvar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var nome = tbNome.Text;
                var email = tbEmail.Text;
                var sexo = tbSexo;
                var telefone = tbTelefone.Text;

                if(btpDataNasc.SelectedDate != null)
                {
                    DateTime dataNasc = (DateTime) btpDataNasc.SelectedDate;

                    var sql = "INSERT INTO contato (data_nasc_con, nome_con, email_con, telefone_con, sexo_con) VALUES (@_data_nasc, @_nome, @_email, @_telefone, @_sexo);";
                    var comando = new MySqlCommand(sql, _conexao);

                    comando.Parameters.AddWithValue("@_data_nasc", dataNasc.ToString("yyyy-MM-dd"));
                    comando.Parameters.AddWithValue("@_nome", nome);
                    comando.Parameters.AddWithValue("@_email", email);
                    comando.Parameters.AddWithValue("@_telefone", telefone);
                    comando.Parameters.AddWithValue("@_sexo", sexo);
                    comando.ExecuteNonQuery();

                    MessageBox.Show("SALVO COM SUCESSO!");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            tbEmail.Clear();
            tbNome.Clear();
            tbTelefone.Clear();   
        }
    }
}


