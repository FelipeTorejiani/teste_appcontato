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
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Cms;

namespace WPF_ProjetoPDS.Formulario
{
    /// <summary>
    /// Lógica interna para ListarContato.xaml
    /// </summary>
    public partial class ListarContato : Window
    {
        private MySqlConnection _conexao;
        public ListarContato()
        {
            InitializeComponent();
            Conexao();
            Listar();
        }

        private void Conexao()
        {
            string conexaoString = "serve=localhst;datsbase=app_contato_bd;user=root;password=root;port=3360";
            _conexao = new MySqlConnection(conexaoString);
            _conexao.Open();
        }

        private void Listar()
        {
            string sql = "Select * from Contato";
            var comando = new MySqlCommand(sql, _conexao);
            var reader = comando.ExecuteReader();
            var lista = new List<Object>();

            while (reader.Read())
            {
                string data = "";
                try
                {
                    data = reader.GetDateTime("data_nas_con").ToString("dd/MM/yyyy");
                }
                catch { }

                var contato = new
                {
                    Data_nascimento = data,
                    Nome = reader.GetString(2),
                    Email = reader.GetString(3),
                    Telefone = reader.GetString(4),
                    Sexo = reader.GetString(5),
                };
                lista.Add(contato);

            }
            DT.ItemsSource = lista;
        }
    }
}
