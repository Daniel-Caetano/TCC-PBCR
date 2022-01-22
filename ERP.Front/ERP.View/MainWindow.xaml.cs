using ERP.View.Negocio;
using System;
using System.Collections.Generic;
using System.IO;
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
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Collections.ObjectModel;
using ERP.View;
namespace ERP.View
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        //  ObservableCollection<Recibo> collection = new ObservableCollection<Recibo>();
        //  List<Recibo> listaRecibos = new List<Recibo>();
        //  ReciboService serviceRecibo = new ReciboService();
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;

        }



        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() => CarregarGrid()), System.Windows.Threading.DispatcherPriority.ContextIdle);
        }

        public async Task CarregarGrid()
        {
            // var recibos = await serviceRecibo.GetAsync();
            //  dataGridRecibo.ItemsSource = recibos;
        }

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

        private void Visualizar(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Visualizar");

        }

        private void Deletar(object sender, RoutedEventArgs e)
        {

            /* var deletarRecibo = dataGridRecibo.SelectedItem as ReciboResponse;
             if (deletarRecibo != null)
             {
                 MessageBox.Show("Deletar" + deletarRecibo.Numero.ToString());
             }
            */
        }

    }

}
