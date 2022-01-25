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

        ReciboService serviceReciboID = new ReciboService();

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

        public void BuscarRecibo(object sender, RoutedEventArgs e)
        {
            int search = int.Parse(txtSearch.Text);
            
            //MessageBox.Show(search.ToString());
            CarregaID(search);
        }

        public async Task CarregaID(int id)
        {

            {
                var recibos = await serviceReciboID.GetAsync(id);
                MessageBox.Show(recibos.ToString());
                dataGridRecibo.ItemsSource = recibos;
            }

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

        private void Gerar(object sender, RoutedEventArgs e)
        {
            ReciboJanela.MainWindow recibo = new ReciboJanela.MainWindow();
            recibo.Show();
            MessageBox.Show("Clicou Botão");
        }


        private void Visualizar(object sender, RoutedEventArgs e)
        {
            /*
            var infoRecibo = dataGridRecibo.SelectedItem as ReciboResponse;

            if (infoRecibo != null)
            {

                string Valor = infoRecibo.Valor.ToString();  //Recebendo valor do formulário
                string Numero = infoRecibo.Numero.ToString();
                string Tipo = infoRecibo.Tipo.ToString();
                string Observacao = infoRecibo.Observacao.ToString();
                string Cidade = infoRecibo.Cidade.ToString();
                string Estado = infoRecibo.Estado.ToString();
                DateTime Data = infoRecibo.Data;



                 ReciboJanela.Imprimir imprimir = new ReciboJanela.Imprimir();  //Instancia a classe da JanelaRecibo()
                imprimir.VisualizarRecibo(Numero, Tipo, Valor, Observacao, Cidade, Estado, Data); //Enviando somente 1 dados (valor) NÃO PRECISA COLOCAR O TIPO DE VARIÁVEL
                //imprimir.VisualizarRecibo(infoRecibo.ToString());  //Envidando todos os das
                imprimir.Show(); //Precisa para imprimir o objeto na tela


                //recibo.VisualizaRecibo(dados); //Pega o método da classe 
               //MessageBox.Show(dados);
            }
            */

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
                MessageBox.Show("Deletar Recibo");
            }
            else
            {
                MessageBox.Show("Recibo Não Válido");
            }

        }

    }
}