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
using System.Windows.Shapes;

namespace ERP.View
{
    /// <summary>
    /// Interaction logic for Imprimi.xaml
    /// </summary>
    public partial class Imprimi : Window
    {
        public Imprimi()
        {
            InitializeComponent();
        }
        //METODO RESPOSÁVEL POR PREENCHER O RECIBO
        public void PreVisualizarRecibo(string NomeRecebedor, string LogradouroRecebedor, string NumeroEnderecoRecebedor,
                                         string ComplementoRecebedor, string CEPRecebedor, string BairroRecebedor,
                                         string cpF_CNPJPagador, double _Valor, string ValorExtenso,
                                         string Observacao, string CidadeRecebedor, string UFRecebedor, string CPF_CNPJRecebedor, string NomePagador)
        {
            //RECEBEDOR
            iNomeRecebedor.Text = NomeRecebedor;
            iLogradouroRecebedor.Text = LogradouroRecebedor;
            iNumeroEnderecoRecebedor.Text = NumeroEnderecoRecebedor;
            iComplementoRecebedor.Text = ComplementoRecebedor;
            iCEPRecebedor.Text = CEPRecebedor;
            iBairroRecebedor.Text = BairroRecebedor;
            iCPF_CNPJRecebedor.Text = CPF_CNPJRecebedor;
            iNomePagador.Text = NomePagador;

            //PAGADOR
            icpF_CNPJPagador.Text = cpF_CNPJPagador;
            iValor.Text = _Valor.ToString();
            iValorExtenso.Text = ValorExtenso;
            iObservacao.Text = Observacao;
            iCidadeRecebedor.Text = CidadeRecebedor;
            iFRecebedor.Text = UFRecebedor;



        }
  
        private void GerarReciboPDF(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Clicou");
            //RECEDOR
            string NomeRecebedor = iNomeRecebedor.Text;
            string LogradouroRecebedor = iLogradouroRecebedor.Text;
            string NumeroEnderecoRecebedor = iNumeroEnderecoRecebedor.Text;
            string ComplementoRecebedor = iComplementoRecebedor.Text;
            string CEPRecebedor = iCEPRecebedor.Text;
            string BairroRecebedor = iBairroRecebedor.Text;
            string CPF_CNPJRecebedor = iCPF_CNPJRecebedor.Text;

            //PAGADOR
            string NomePagador = iNomePagador.Text;
            string cpF_CNPJPagador = icpF_CNPJPagador.Text;
            string Valor = iValor.Text;
            string ValorExtenso = iValorExtenso.Text;
            string Observacao = iObservacao.Text;
            string CidadeRecebedor = iCidadeRecebedor.Text;
            string FRecebedor = iFRecebedor.Text;

            ReciboList reciboList = new ReciboList();
            reciboList.GerarPDF(NomeRecebedor, LogradouroRecebedor, NumeroEnderecoRecebedor, ComplementoRecebedor, CEPRecebedor, BairroRecebedor, CPF_CNPJRecebedor, NomePagador, cpF_CNPJPagador, Valor, ValorExtenso, Observacao, CidadeRecebedor, FRecebedor);
        }
    }
}
