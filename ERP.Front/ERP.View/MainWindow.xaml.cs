using ReciboJanela;
using ERP.ViewApi.Servicos.Servico;
using ERP.ViewApi.Negocio;
using ERP.View.Negocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Collections.ObjectModel;
namespace ERP.View
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;

        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {

        }
                

        private void addCliente(object sender, RoutedEventArgs e)
        {

            Main.Content = new ClienteForm();

        }


        private void listCliente(object sender, RoutedEventArgs e)
        {

        }

        private void ListarRecibo(object sender, RoutedEventArgs e)
        {
            Main.Content = new ReciboList();
        }

    
        
    }

}
