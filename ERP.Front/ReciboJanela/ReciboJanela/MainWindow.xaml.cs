using System;
using System.Collections.Generic;
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

        Dados dados = new Dados();
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }
        public void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
                   
        }
        private void butSalvar_Click(object sender, RoutedEventArgs e)
        {
          
            dados.ValorRecebido = (txtValor.Text);
            dados.RecebemosDe = txtExtenso.Text;
            dados.Cpf = txtCpf.Text;
            dados.Cnpj = txtCnpj.Text;
            dados.ImportanciDe = txtImpor.Text;
            dados.Referente = txtRef.Text;
            txtDataAtual.Text = DateTime.Now.ToString("dd/MM/yyyy");
            dados.Data = txtDataAtual.Text;
                       
            MessageBox.Show($"Valor: {dados.ValorRecebido}\n" +
               $"Recebi (emos) de: {dados.RecebemosDe}\n" +
               $"CPF: {dados.Cpf}\n" +
               $"CNPJ: {dados.Cnpj}\n" +
               $"a importancia de: {dados.ImportanciDe}\n"
               + $"referente á: {dados.Referente}\n" + $"na data {dados.Data}",
               "Informações", MessageBoxButton.OK, MessageBoxImage.Information);
            
            txtValor.Text = "";
            txtExtenso.Text = "";
            txtCpf.Text = "";
            txtCnpj.Text = "";
            txtData.Text = "";
            txtRef.Text = "";
        }

        private void butImp_Click(object sender, RoutedEventArgs e)
        {
            Imprimir imp = new Imprimir();
            imp.ShowDialog();
        }
        private void txtCpf_LostFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            string cpf = txtCpf.Text;
            cpf = Validacao.RetirarMascara(cpf);

            if(txtCpf.IsFocused == true)
            {
                txtCnpj.IsEnabled = false;
                txtCnpj.Background = Brushes.Green;
            }

           
            if (!Validacao.ValidarCpf(cpf))
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
        private void txtCnpj_TextChanged(object sender, KeyboardFocusChangedEventArgs e)
        {
            string cnpj = txtCnpj.Text;
            cnpj = Validacao.RetirarMascara(cnpj);

            if(txtCnpj.IsFocused == true)
            {
                txtCpf.IsEnabled = false;
            }
  
            if (!Validacao.ValidarCnpj(cnpj))
            {
                e.Handled = true;
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

