using System.Collections.Generic;
using System.Windows;

namespace ERP.View
{
    /// <summary>
    /// Interaction logic for ClienteList.xaml
    /// </summary>
    public partial class ClienteList : Window
    {
        public ClienteList()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;

        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {

            List<TestDados> list = new List<TestDados>();

            for (int i = 0; i < 10; i++)
            {
                list.Add(new TestDados()
                {
                    Id = 1 + i,
                    Nome = "Mauro" + i,
                    Cpf = "001.231.459-90",
                    Cep = "74985-421",
                    Cidade = "Aparecida de Goiânia" + i,
                    Estado = "Goiás" + i,

                });
            }

            dataGridCliente.ItemsSource = list;

        }
    }
}
