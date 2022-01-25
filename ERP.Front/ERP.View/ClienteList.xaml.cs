
﻿using ReciboJanela;
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
            else if (Regex.IsMatch(txtSearch.Text, @"^[a-z A-Z]+$"))
            {
                MessageBox.Show("Digitou string");

            }
            else
                CarregarGrid();
        }


        public async Task CarregaDadosRecibo(string Dados)
        {
            var recibos = await serviceRecibo.GetAsyncDocumento(Dados);
          //  dataGridRecibo.ItemsSource = recibos;
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
                PdfWriter escritorPDF = PdfWriter.GetInstance(document, arquivoPDF);


                document.Open();
                string dados = "";
                string DataAtual = DateTime.Now.ToString("dd/MM/yyyy");

                //GERANDO OS DADOS PARA PDF
                iTextSharp.text.Paragraph paragrafo = new iTextSharp.text.Paragraph(dados, new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 14, iTextSharp.text.Font.BOLD)); ;
                paragrafo.Alignment = Element.ALIGN_LEFT;

                paragrafo.Add("RECIBO \n \n");

                paragrafo.Font = new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 14);
                paragrafo.Alignment = Element.ALIGN_LEFT;
                paragrafo.Add("Eu " + NomeRecebedor + "(" + CPF_CNPJRecebedor + "),  localizado em "
                            + LogradouroRecebedor + ", " + NumeroEnderecoRecebedor + ", " + ComplementoRecebedor + ",\n"
                            + CEPRecebedor + ", " + BairroRecebedor + "," + CidadeRecebedor + "-" + FRecebedor + " \n " +
                            " declaro para os fins que recebi " + NomePagador + "(" + cpF_CNPJPagador + ") o valor de R$ " + Valor + ", "
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
                paragrafo.Add(cpF_CNPJPagador + "n \n\n");


                document.Add(paragrafo);
                document.Close();
            }


        }


        private void Gerar(object sender, RoutedEventArgs e)
        {
            ReciboJanela.MainWindow recibo = new ReciboJanela.MainWindow();
            recibo.Show();
            MessageBox.Show("Clicou Botão");
        }

        private void Visualizar(object sender, RoutedEventArgs e)
        {

            var infoRecibo = dataGridPessoa.SelectedItem as ReciboResponse;

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

                DateTime Data = infoRecibo.Data;



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
            var deletarRecibo = dataGridPessoa.SelectedItem as ReciboResponse;
            if (deletarRecibo != null)
            {

                ReciboJanela.MainWindow recibo = new ReciboJanela.MainWindow();
                recibo.Show();
                MessageBox.Show("Selecionou para Editar");
            }
            else
            {
                MessageBox.Show("Recibo Não Válido");
            }

        }

        private void Deletar(object sender, RoutedEventArgs e)
        {
            var deletarRecibo = dataGridPessoa.SelectedItem as ReciboResponse;
            if (deletarRecibo != null)
            {
                MessageBox.Show("Deletar Recibo");
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

    }
}
