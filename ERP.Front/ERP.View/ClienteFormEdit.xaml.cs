using ReciboJanela;
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
using System.Text.RegularExpressions;

namespace ERP.View
{
    /// <summary>
    /// Interaction logic for ClienteFormEdit.xaml
    /// </summary>
    public partial class ClienteFormEdit : Window
    {
        readonly PessoaService pessoaService = new PessoaService();

        public ClienteFormEdit()
        { 

            
            InitializeComponent();     
            
           
        }    

        private void AtualizarCliente(object sender, RoutedEventArgs e)
        {
            string Nome = txtNome.Text;
            string CPF = txtCpf.Text;
            string CEP = txtCep.Text;
            string Bairro = txtBairro.Text;
            string Localidade = txtCidade.Text;
            string UF = txtEstado.Text;
            string Complemento = txtComplemento.Text;
            string Logradouro = txtLogradouro.Text;
            string NumeroEndereco = txtNumero.Text;

            _ = AtualizarClienteBanco(CPF, Nome, CPF, NumeroEndereco, 
                                      Complemento, CEP, Logradouro, 
                                      Bairro, Localidade, UF);
        }

        public async Task AtualizarClienteBanco(string CpfAutal, string Nome, string CPF, 
                                                string NumeroEndereco, string Complemento, 
                                                string CEP, string Logradouro, string Bairro, 
                                                string Localidade, string UF)
        {
            _ = await pessoaService.UpdateAsync(CpfAutal, Nome, CPF, 
                                                NumeroEndereco, Complemento, 
                                                CEP, Logradouro, Bairro, Localidade, UF);
            Close();    
        }
    }
}
