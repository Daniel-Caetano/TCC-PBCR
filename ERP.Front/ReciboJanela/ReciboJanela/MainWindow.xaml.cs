using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace ReciboJanela
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

        }

        public void ButSalvar_Click(string data)
        {


            Dados dados = new Dados
            {
                ValorRecebido = (txtValor.Text),
                RecebemosDe = txtExtenso.Text,
                Cpf = txtCpf.Text,
                Cnpj = txtCnpj.Text,
                ImportanciDe = txtImpor.Text,
                Referente = txtRef.Text
            };

            txtDataAtual.Text = DateTime.Now.ToString("dd/MM/yyyy");
            dados.Data = txtDataAtual.Text;

            MessageBox.Show($"Valor: {dados.ValorRecebido}\n" +
                            $"Recebi (emos) de: {dados.RecebemosDe}\n" +
                            $"CPF: {dados.Cpf}\n" +
                            $"CNPJ: {dados.Cnpj}\n" +
                            $"a importancia de: {dados.ImportanciDe}\n" +
                            $"referente á: {dados.Referente}\n" + $"na data {dados.Data}",
                            $"Informações", MessageBoxButton.OK, MessageBoxImage.Information);

            txtValor.Text = "";
            txtExtenso.Text = "";
            txtCpf.Text = "";
            txtCnpj.Text = "";
            txtData.Text = "";
            txtRef.Text = "";
        }

        private void ButImp_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog imp = new PrintDialog();
           imp.ShowDialog();
        }

        private void TxtCpf_LostFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            Validacao tmp = new Validacao();
            string tratativa = tmp.RetirarMascara(txtCpf.Text);
            

            if (txtCpf.IsFocused == true)
            {
                txtCnpj.IsEnabled = false;
                txtCnpj.Background = Brushes.Green;
            }


            if (!tmp.ValidarCpf(tratativa))
            {

                e.Handled = true;
                txtCpf_Erro.Visibility = Visibility.Visible;
                txtCpf_Erro.Focus();
            }
            else
            {
                txtCpf_Erro.Visibility = Visibility.Collapsed;
            }

        }

        private void TxtCnpj_TextChanged(object sender, KeyboardFocusChangedEventArgs e)
        {
            Validacao tmp = new Validacao();
            string tratativa = tmp.RetirarMascara(txtCnpj.Text);

            if (txtCnpj.IsFocused == true)
            {
                txtCpf.IsEnabled = false;
                txtCpf.Background = Brushes.Green;
            }

            if(!tmp.ValidarCnpj(tratativa))
            { 
                txtCnpj_Erro.Visibility = Visibility.Visible;
                txtCnpj_Erro.Focus();
            }

            else
            {
                txtCnpj_Erro.Visibility = Visibility.Collapsed;
                
            }
        }
    }
}

