using ERP.View.Negocio;
using ERP.ViewApi.Negocio;
using ERP.ViewApi.Servicos.Servico;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;



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

            var recibos = await serviceRecibo.GetAsyncAll();

            dataGridRecibo.ItemsSource = recibos;
        }
        //Metodo verifica se o cpf ou cnpj é válido após isso carrega o mesmo na listagem da janela
        public void BuscarRecibo(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(txtSearch.Text, @"^[0-9]+$"))
            {
                if (txtSearch.Text != "" && txtSearch.Text.Length == 11)
                {
                    string search = txtSearch.Text.ToString();
                    CarregaDadosRecibo(search);
                }
                else if (txtSearch.Text != "" && txtSearch.Text.Length == 14)
                {
                    string search = txtSearch.Text.ToString();
                    CarregaDadosRecibo(search);

                }
            }
            else if(txtSearch.Text !="")
            {
                
                string search = txtSearch.Text.ToString();
                CarregarDadosNome(search);

            }
            else
                
            CarregarGrid();
          
        }

        //Medo recebe os dados do banco de acordo com a pesquisa e exibe na janela
        public async Task CarregaDadosRecibo(string Dados)
        {
            var recibos = await serviceRecibo.GetAsyncDocumento(Dados);
            dataGridRecibo.ItemsSource = recibos;
        }
     
        public async Task CarregarDadosNome(string Dados)
        {
            var recibos = await serviceRecibo.GetAsyncNome(Dados);
            dataGridRecibo.ItemsSource = recibos;
        }

        public void GerarPDF(string NomeRecebedor, string CPF_CNPJRecebedor, string ComplementoRecebedor,
                             string CEPRecebedor, string CidadeRecebedor, string FRecebedor,
                             string LogradouroRecebedor, string NumeroEnderecoRecebedor,
                             string BairroRecebedor, string NomePagador, string cpF_CNPJPagador, string Valor, string ValorExtenso, string Observacao)

        {
            if (NomePagador != "")
            {

                //CHAMANDO A BIBLIOTECA COM  O CAMINHO E INSTANCIANDO A CLASSE PARA GERAR O PDF

                string nomeArquivo = @"C:\PDF\" + NomeRecebedor + ".pdf";
                FileStream arquivoPDF = new FileStream(nomeArquivo, FileMode.Create);
                Document document = new Document(PageSize.A4);
                _ = PdfWriter.GetInstance(document, arquivoPDF);
                string DataAtual = DateTime.Now.ToString("dd/MM/yyyy");

                document.Open();
                string dados = "";

                //GERANDO OS DADOS PARA PDF
                iTextSharp.text.Paragraph paragrafo = new iTextSharp.text.Paragraph(dados, new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 14, iTextSharp.text.Font.BOLD)); ;
                paragrafo.Alignment = Element.ALIGN_LEFT;

                paragrafo.Add("RECIBO \n \n");

                paragrafo.Font = new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 14);
                paragrafo.Alignment = Element.ALIGN_LEFT;
                paragrafo.Add("Eu " + NomeRecebedor + " de CPF/CNPJ " + CPF_CNPJRecebedor +  ",\n localizado em "
                            + LogradouroRecebedor + " " + NumeroEnderecoRecebedor + ComplementoRecebedor + ", \n"
                            + CEPRecebedor + ", " + BairroRecebedor + ", " + CidadeRecebedor + " - " + FRecebedor + ", \n " +
                            " declaro para os devidos fins que recebi de " + NomePagador + " CPF/CNPJ " + cpF_CNPJPagador + ", o valor de R$ " + Valor + ", "
                            + ValorExtenso + ", em virtude de " + Observacao + ".\n \n");

                paragrafo.Alignment = Element.ALIGN_LEFT;
                paragrafo.Add("Goiânia-GO, " + DataAtual + "\n \n");

                paragrafo.Alignment = Element.ALIGN_CENTER;
                paragrafo.Add("_________________________________________________________\n");
                paragrafo.Add(NomeRecebedor + "\n");
                paragrafo.Add(CPF_CNPJRecebedor + "\n \n");

                paragrafo.Alignment = Element.ALIGN_CENTER;
                paragrafo.Add("_________________________________________________________\n");
                paragrafo.Add(NomePagador + "\n");
                paragrafo.Add(cpF_CNPJPagador + " \n\n");

                document.Add(paragrafo);

                document.Close();
            }
        }


        //Metodo realiza chamada da janela recibo
        private void Gerar(object sender, RoutedEventArgs e)
        {
            ReciboJanela.MainWindow recibo = new ReciboJanela.MainWindow();
            recibo.Show();  
        }
       
        //Metodo carrega na tela a janela de pré-visualização do recibo
        private void Visualizar(object sender, RoutedEventArgs e)
        {
            var infoRecibo = dataGridRecibo.SelectedItem as ReciboResponse;

            if (infoRecibo != null)
            {

                /*Dados dos Recebedor*/
                string NomeRecebedor = infoRecibo.NomeRecebedor.ToString();
                string LogradouroRecebedor = infoRecibo.LogradouroRecebedor.ToString();
                string NumeroEnderecoRecebedor = infoRecibo.NumeroEnderecoRecebedor.ToString();
                string ComplementoRecebedor = infoRecibo.ComplementoRecebedor.ToString();
                string CPF_CNPJRecebedor = infoRecibo.CPF_CNPJRecebedor.ToString();
                string CEPRecebedor = infoRecibo.CEPRecebedor.ToString();
                string BairroRecebedor = infoRecibo.BairroRecebedor.ToString();

                /*Dados do Pagador*/
                string NomePagador = infoRecibo.NomePagador.ToString();
                string cpF_CNPJPagador = infoRecibo.CpF_CNPJPagador.ToString();
                double _Valor = (double)infoRecibo.Valor;
                string ValorExtenso = infoRecibo.ValorExtenso.ToString();
                string Observacao = infoRecibo.Observacao.ToString();
                string CidadeRecebedor = infoRecibo.CidadeRecebedor.ToString();
                string UFRecebedor = infoRecibo.UFRecebedor.ToString();
                _ = infoRecibo.Data;

                Imprimi imprimir = new Imprimi();  //Instancia a classe da JanelaRecibo()
                imprimir.PreVisualizarRecibo(NomeRecebedor, LogradouroRecebedor, NumeroEnderecoRecebedor,
                                             ComplementoRecebedor, CEPRecebedor, BairroRecebedor,
                                             cpF_CNPJPagador, _Valor, ValorExtenso,
                                             Observacao, CidadeRecebedor, UFRecebedor, CPF_CNPJRecebedor, NomePagador); ; //Enviando somente 1 dados (valor) NÃO PRECISA COLOCAR O TIPO DE VARIÁVEL

                imprimir.Show(); //Precisa para imprimir o objeto na tela

                //recibo.VisualizaRecibo(dados); //Pega o método da classe 
                //MessageBox.Show(dados);
            }

        }

        private void Editar(object sender, RoutedEventArgs e)
        {
            var deletarRecibo = dataGridRecibo.SelectedItem as ReciboResponse;

            if (deletarRecibo != null)
            {
                ReciboJanela.MainWindow recibo = new ReciboJanela.MainWindow();
                recibo.Show(); 
            }
            else
            {
                MessageBox.Show("Recibo Não Válido");
            }
        }

        private void Deletar(object sender, RoutedEventArgs e)
        {
            var deletarRecibo = dataGridRecibo.SelectedItem as ReciboResponse;
            if (deletarRecibo != null)
            {
                MessageBox.Show("Desja realmente deletar Recibo?");

                this.InitializeComponent();
                CarregarGrid();

                _ = MessageBox.Show("Desja realmente deletar Recibo?", "Lista", MessageBoxButton.YesNo, MessageBoxImage.Question);
            }
            else
            {
                MessageBox.Show("Recibo Não Válido");
            }
        }

        private void LiberarBotao(object sender, RoutedEventArgs e)
        {
            if (txtSearch.Text != "")
            {
                btnSearch.IsEnabled = true;
            }
        }

        public async Task ListarAreceber()
        {
            var recibos = await serviceRecibo.GetAsyncAreceber();
            dataGridRecibo.ItemsSource = recibos;
        }
       
        public async Task ListarApagar()
        {
            var recibos = await serviceRecibo.GetAsyncApagar();
            dataGridRecibo.ItemsSource = recibos;
        }
        
        private void Receber_Checked(object sender, RoutedEventArgs e)
        {
            if (Receber.IsChecked == true ){
                ListarAreceber();
            }          
           
        }

        private void Pagar_Checked(object sender, RoutedEventArgs e)
        {
            if (Pagar.IsChecked == true)
            {
                ListarApagar();
            }
           
        }
    }
}
