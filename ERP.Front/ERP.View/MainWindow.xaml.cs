using ERP.View.Dominio.Clientes;
using System;
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
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;


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
            List<Clientes> listClientes = new List<Clientes>();
            for (int i = 0; i <= 30; i++)
            {
                listClientes.Add(new Clientes()
                {
                    Id = 1 + i,
                    Name = "Cliente" + i,
                    Cpf = "1234567878",
                    Telefone = "62 9 1234-5789",
                    Endereco = "Avenida Brasil"

                });
            }
            dataGridClientes.ItemsSource = listClientes;
        }

        private void imprimir_pdf(object sender, RoutedEventArgs e)
        {
           
            
            //CHAMANDO A BIBLIOTECA COM  O CAMINHO E INSTANCIANDO A CLASSE PARA GERAR O PDF
            string nomeArquivo = @"C:\Users\bruno.oliveira\Desktop\brunoCesar\ERP.View\Pdf\cliente.pdf";
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
    }
}
