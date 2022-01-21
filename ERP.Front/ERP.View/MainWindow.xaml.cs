
using ERP.View.Dominio.Negocio;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

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

        public void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //Criando lista que recebe o get dos recibos
            //ViewApi.Servicos.Servico.ReciboService serviceRecibo = new ViewApi.Servicos.Servico.ReciboService();
            //Imprimindo a os recibos na tela
            //dataGridClientes.ItemsSource = await serviceRecibo.GetAsync();

            //string Data = DateTime.Now.ToString("dd/MM/yyyy");

            List<Recibo> listRecibo = new List<Recibo>();

            for (int i = 0; i <= 20; i++)
            {
                listRecibo.Add(new Recibo()
                {
                    Numero = 1 + i,
                    Tipo = "Recibo Pago",
                    Valor = "142,25",
                    Data = "21/01/2022"

                });
            }
            dataGridClientes.ItemsSource = listRecibo;
        }
        //Crie a pasta Pdf no C:\
        private void GerarPdf(object sender, RoutedEventArgs e)
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
            paragrafo.Add("Eu <nome> (CPF/CNPJ_RECEBOR),localizado em \n <logradouro_recebor>, <número_endereço_recebedor> <complemento_recebedor>,\n <CEP_recebor>,<bairro_recebedor>," +
                "<cidade_recebedor>,\n declaro para os fins que recebi <nome/razão_social_pagador> (CPF/CNPJ_RECEBOR), o valor de R$ <valor_documento>(<valor_documento_por_extendo> " +
                "em virtude de <observação_documento>");

            iTextSharp.text.Paragraph paragrafo1 = new iTextSharp.text.Paragraph(dados, new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 14, iTextSharp.text.Font.BOLD));
            paragrafo.Alignment = Element.ALIGN_CENTER;
            paragrafo.Add("<cidade_corrente>-<estado_corrente>,<data_corrente> \n");


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

        private void visualizar(object sender, RoutedEventArgs e)
        {
            PrintDialog obj = new PrintDialog();
            obj.ShowDialog();

        }

        private void AdicionarRecibo(object sender, RoutedEventArgs e)
        {
            ReciboJanela.MainWindow adicionar = new ReciboJanela.MainWindow();
            adicionar.ShowDialog();
        }
    }
}
