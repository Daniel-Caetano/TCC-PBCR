using System.Windows;

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
            iCPF_CNPJRecebedor.Text = Formatar(CPF_CNPJRecebedor);
            iNomePagador.Text = NomePagador;

            //PAGADOR
            icpF_CNPJPagador.Text = Formatar(cpF_CNPJPagador);
            iValor.Text = _Valor.ToString();
            iValorExtenso.Text = ValorExtenso;
            iObservacao.Text = Observacao;
            iCidadeRecebedor.Text = CidadeRecebedor;
            iFRecebedor.Text = UFRecebedor;

            // NOME E CPF/CNPF que seão plotados no recibo
            iiNomeRecebedor.Text = NomeRecebedor;
            iiCPF_CNPJRecebedor.Text = Formatar(CPF_CNPJRecebedor);
            iiNomePagador.Text = NomePagador;
            iicpF_CNPJPagador.Text = Formatar(cpF_CNPJPagador);
            dataCorrente.Text = DateTime.Now.ToString("dd/MM/yyyy");

        }
        public string Formatar(string cncp)
        {
            if (cncp.Length == 14)
            {
                return Convert.ToInt64(cncp).ToString(@"00\.000\.000\/0000-00");
            }
            else
            {
                return Convert.ToInt64(cncp).ToString(@"000\.000\.000\.000-00");
            }

        }
    }
}
