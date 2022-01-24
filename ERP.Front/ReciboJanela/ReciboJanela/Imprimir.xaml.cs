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

namespace ReciboJanela
{
    /// <summary>
    /// Lógica interna para Imprimir.xaml
    /// </summary>
    public partial class Imprimir : Window
    {
        public Imprimir()
        {

            InitializeComponent();
            Loaded += MainWindow_loaded;
            

        }
        public void MainWindow_loaded(object sender, RoutedEventArgs e)
        {
           // MessageBox.Show("Dentro da classe Imprimir com o Método MainWindo_loaded");
        }
        public void VisualizarRecibo(string valor)
        {
            dadosRecibos.Text = valor;
            //txtValor = valor;
           //MessageBox.Show("Dentro do método visualizar Recibo ");  
            
        }


    }
}
