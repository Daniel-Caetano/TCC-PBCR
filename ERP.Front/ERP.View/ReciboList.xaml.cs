using ReciboJanela;
using ERP.ViewApi.Servicos.Servico;
using ERP.ViewApi.Negocio;
using ERP.View.Negocio;
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
using System;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Collections.ObjectModel;



namespace ERP.View
{
    /// <summary>
    /// Interaction logic for ReciboList.xaml
    /// </summary>
    public partial class ReciboList : Page
    {

        ObservableCollection<Recibo> collection = new ObservableCollection<Recibo>();

        List<Recibo> listaRecibos = new List<Recibo>();
        ReciboService serviceRecibo = new ReciboService();


        public ReciboList()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }
       
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            #pragma warning disable CS4014 // Como esta chamada não é esperada, a execução do método atual continua antes de a chamada ser concluída
            _ = Dispatcher.BeginInvoke(new Action(() => CarregarGrid()), System.Windows.Threading.DispatcherPriority.ContextIdle);
        }

        public async Task CarregarGrid()
        {
            {
                
                var recibos = await serviceRecibo.GetAsync();
                foreach (var elemento in recibos)
                {
                    // MessageBox.Show(elemento.Numero.ToString());
                }
                dataGridRecibo.ItemsSource = recibos;
               

            }

        }

        private void BuscarRecibo(object sender, RoutedEventArgs e)
        {
            string search = txtSearch.Text;
            MessageBox.Show(search);
        }
    }
}
