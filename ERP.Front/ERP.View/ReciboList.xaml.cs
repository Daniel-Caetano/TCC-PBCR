using ERP.View.Negocio;
using ERP.ViewApi.Negocio;
using ERP.ViewApi.Servicos.Servico;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            _ = Dispatcher.BeginInvoke(new Action(() => CarregarGrid()), System.Windows.Threading.DispatcherPriority.ContextIdle);
        }

        public async Task CarregarGrid()
        {
            var recibos = await serviceRecibo.GetAsyncAll();
            foreach (var elemento in recibos)
            {
                // MessageBox.Show(elemento.Numero.ToString());
            }

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
            else if (Regex.IsMatch(txtSearch.Text, @"^[a-z A-Z]+$"))
            {
                MessageBox.Show("Digitou string");

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


        private void GerarPdf(object sender, RoutedEventArgs e)
        {
            /*
             var infoRecibo = dataGridRecibo.SelectedItem as ReciboResponse;

             if (infoRecibo != null)
             {

                 //CHAMANDO A BIBLIOTECA COM  O CAMINHO E INSTANCIANDO A CLASSE PARA GERAR O PDF
                 string nomeArquivo = @"C:\Pdf\cliente.pdf";
                 FileStream arquivoPDF = new FileStream(nomeArquivo, FileMode.Create);
                 Document document = new Document(PageSize.A4);
                 PdfWriter escritorPDF = PdfWriter.GetInstance(document, arquivoPDF);


                 document.Open();
                 string dados = "";

                 //GERANDO OS DADOS PARA PDF
                 iTextSharp.text.Paragraph paragrafo = new iTextSharp.text.Paragraph(dados, new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 14, iTextSharp.text.Font.BOLD));
                 paragrafo.Alignment = Element.ALIGN_CENTER;
                 paragrafo.Add("RECIBO \n");

                 paragrafo.Font = new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 14);
                 paragrafo.Alignment = Element.ALIGN_LEFT;
                 paragrafo.Add("Eu " + infoRecibo.Numero + " (CPF/CNPJ_RECEBOR),localizado em \n <logradouro_recebor>, <número_endereço_recebedor> <complemento_recebedor>,\n <CEP_recebor>,<bairro_recebedor>," +
                     ",\n declaro para os fins que recebi <nome/razão_social_pagador> (CPF/CNPJ_RECEBOR), o valor de R$ " + infoRecibo.Valor + ", " + infoRecibo.ValorExtenso +
                     "em virtude de <observação_documento>");

                 iTextSharp.text.Paragraph paragrafo1 = new iTextSharp.text.Paragraph(dados, new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 14, iTextSharp.text.Font.BOLD));
                 paragrafo.Alignment = Element.ALIGN_CENTER;
                 paragrafo.Add(infoRecibo.Cidade + "," + infoRecibo.Estado + " \n");


                 paragrafo1.Alignment = Element.ALIGN_CENTER;
                 paragrafo1.Add("---------------------------------------------------------- \n");
                 paragrafo1.Add("<cidade_corrente>-<estado_corrente>,<data_corrente> \n");
                 paragrafo1.Add("<nome/razão_social_pagador> \n");
                 paragrafo1.Add(" (CPF/CNPJ_RECEBOR), \n\n\n");

                 string cpf = "1234567891011";
                 string pagador = "Bruno Cesar de Oliveira";

                 paragrafo.Add("---------------------------------------------------------- \n");
                 paragrafo.Add("<cidade_corrente>-<estado_corrente>,<data_corrente> \n");
                 paragrafo.Add("<nome/razão_social_pagador> \n");
                 paragrafo.Add(cpf + pagador + "\n\n\n");


                 document.Add(paragrafo);
                 document.Close();
             }
         */
        }

        //Metodo realiza chamada da janela recibo
        private void Gerar(object sender, RoutedEventArgs e)
        {
            ReciboJanela.MainWindow recibo = new ReciboJanela.MainWindow();
            recibo.Show();
            MessageBox.Show("Clicou Botão");
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
            var deletarRecibo = dataGridRecibo.SelectedItem as ReciboResponse;
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
            var deletarRecibo = dataGridRecibo.SelectedItem as ReciboResponse;
            if (deletarRecibo != null)
            {
                MessageBox.Show("Desja realmente deletar Recibo?");
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
