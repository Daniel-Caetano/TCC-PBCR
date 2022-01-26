
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
using System.Text.RegularExpressions;



namespace ERP.View
{
    /// <summary>
    /// Interaction logic for ClienteList.xaml
    /// </summary>
    public partial class ClienteList : Page
    {
        public ClienteList()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;

        }

        ObservableCollection<Recibo> collection = new ObservableCollection<Recibo>();
        List<Recibo> listaRecibos = new List<Recibo>();
        ReciboService serviceRecibo = new ReciboService();
        PessoaService servicePessoa = new PessoaService();

        public object FormEdit { get; private set; }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {


                #pragma warning disable CS4014 // Como esta chamada não é esperada, a execução do método atual continua antes de a chamada ser concluída

            _ = Dispatcher.BeginInvoke(new Action(() => CarregarGrid()), System.Windows.Threading.DispatcherPriority.ContextIdle);
        }

        public async Task CarregarGrid()
        {
            var recibos = await servicePessoa.GetAsyncAll();

            dataGridPessoa.ItemsSource = recibos;
        }

        public void BuscarCliente(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(txtSearch.Text, @"^[0-9]+$"))
            {
                if (txtSearch.Text != "" && txtSearch.Text.Length == 11)
                {

                    string search = txtSearch.Text.ToString();
                    //   CarregaDadosCliente(search);
                }
                else if (txtSearch.Text != "" && txtSearch.Text.Length == 14)
                {
                    string search = txtSearch.Text.ToString();
                    //    CarregaDadosCliente(search);

                }
            }
            else if (Regex.IsMatch(txtSearch.Text, @"^[a-z A-Z]+$"))
            {
               

            }
            else
                CarregarGrid();
        }

        private void Editar(object sender, RoutedEventArgs e)
        {
            var dados = dataGridPessoa.SelectedItem as PessoaResponse;
            if (dados.CPF != null)
            {

                ClienteFormEdit EditarCliente = new ClienteFormEdit();

                EditarCliente.txtNome.Text = dados.Nome;
                EditarCliente.txtCpf.Text = dados.CPF;
                EditarCliente.txtCep.Text = dados.CEP;
                EditarCliente.txtBairro.Text = dados.Bairro;
                EditarCliente.txtCidade.Text = dados.Localidade;
                EditarCliente.txtEstado.Text = dados.UF;
                EditarCliente.txtComplemento.Text = dados.Complemento;
                EditarCliente.txtLogradouro.Text = dados.Logradouro;
                EditarCliente.txtNumero.Text = dados.NumeroEndereco;
                EditarCliente.txtComplemento.Text = dados.Complemento;
                EditarCliente.Show();
            }
            else
            {
                MessageBox.Show("Recibo Não Válido");
            }

        }

        private void Deletar(object sender, RoutedEventArgs e)
        {
            var deletarCliente = dataGridPessoa.SelectedItem as PessoaResponse;
            if (deletarCliente != null)
            {
                MessageBoxResult result = MessageBox.Show("Deseja realmente sair da aplicação?", "App  - Cadastro de pessoas",
                MessageBoxButton.YesNo, MessageBoxImage.Question); //Messagem para sair do applicativo
                //this.Close();
                if (result == MessageBoxResult.Yes)
                {
                    PessoaService deletarPessoa = new PessoaService();
                    deletarPessoa.DeleteAsync(deletarCliente.CPF);
                    if (deletarPessoa != null)
                    {
                        this.InitializeComponent();
                        CarregarGrid();
                        this.DataContext = null;

                    }

                }
                else
                {
                    MessageBox.Show("Recibo Não Válido");
                }

            }
        }

        private void LiberarBotao(object sender, RoutedEventArgs e)
        {
            if (txtSearch.Text != "")
            {
                btnSearch.IsEnabled = true;

            }
        }



    }
}
