using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WPF_ProjetoPDS.RegraDeNegocio
{
    internal class Cadastramento
    {
        public string Nome { get; set; }
        public  string Email { get; set; }
        public string Telefone { get; set; }
        public DatePicker  Data { get; set; }
        public string Sexo { get; set; }    

    }
}
