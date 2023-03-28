using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using ProjetoPDS.Contexto;



namespace ProjetoPDS.Formularios
{
    public partial class FormListarContato : Form
    {
        private MySqlConnection _conexao;
        public FormListarContato()
        {
            InitializeComponent();
            Conexao();
            CarregarDados();

        }

        public void Conexao()
        {
            string conexaoString = "server=localhost;database=app_contato_bd_tore;user=root;password=root;port=3360";
            _conexao = new MySqlConnection(conexaoString);
            _conexao.Open();

        }
        public void CarregarDados()
        {
            var sql = "SELECT * FROM contato ";
            MySqlCommand cmd = new MySqlCommand(sql, _conexao);
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);

            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            this.dataGridView1.DataSource = dataTable;
        }

    }
}
