using System;
using System.Windows;
using System.Windows.Controls;

namespace ReciboJanela
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

        public void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void txtCpf_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtDataAtual.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
    }
}

