using System.Windows;
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

        private void CadastrarRecibo(object sender, RoutedEventArgs e)
        {
            ReciboJanela.MainWindow cadastroRecibo = new ReciboJanela.MainWindow();
            cadastroRecibo.Show();

        }

    }

}
