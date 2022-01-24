using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

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
            MessageBox.Show("Abriu via MainWindow");
        }

 

        public void butSalvar_Click(string data)
        {
            Dados dados = new Dados();

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
        }

        private void butImp_Click(object sender, RoutedEventArgs e)
        {
            //  Imprimir imp = new Imprimir();
            //   imp.ShowDialog();
        }
    }
}

