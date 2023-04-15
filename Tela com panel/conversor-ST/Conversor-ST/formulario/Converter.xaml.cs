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
using Conversor_ST.contexto;
using Conversor_ST.formulario;

namespace Conversor_ST.formulario
{

    /// <summary>
    /// Lógica interna para Converter.xaml
    /// </summary>
    public partial class Converter : Window
    {
        public Converter()
        {
            InitializeComponent();
        }

        private void btConverterTudo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ComboboxConvert.SelectedIndex == 0)
                {
                    double real = Double.Parse(txtReal.Text);
                    double dolar = real * 4.93; // valor da cotação do dólar em 13/04/2023
                    txtDolar.Text = dolar.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: Favor colocar só número");
            }
            try
            {
                if (ComboboxConvert.SelectedIndex == 1)
                {
                    double dolar = Double.Parse(txtReal.Text);
                    double real = dolar * 0.20; //valor do dia 13/04/2023
                    txtDolar.Text = real.ToString();
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Erro: Favor colocar só número");
            }
        }

       
        private void btSair_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

       

        
    }
}
