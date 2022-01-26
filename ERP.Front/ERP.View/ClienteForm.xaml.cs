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
using System.Dynamic;


namespace ERP.View
{
    /// <summary>
    /// Interaction logic for ClienteForm.xaml
    /// </summary>
    public partial class ClienteForm : Page
    {
        PessoaService pessoaService = new PessoaService();
        public ClienteForm()
        {
            InitializeComponent();
        }


        private void CadastrarCliente(object sender, System.Windows.RoutedEventArgs e)
        {
<<<<<<< HEAD
           Imprimi imp = new Imprimi();
           string txt = txtCpfCnpj.Text;

            ReciboJanela.Validacao val = new ReciboJanela.Validacao();


            if(txt.Length >= 11 && txt.Length <= 11)
            {
                val.ValidarCpf(txt);
            }

            if(txt.Length >= 14 && txt.Length <= 14)
            {
                val.ValidarCnpj(txt);
            }
=======
            string Nome = txtNome.Text;
            string CPF = txtCpfCnpj.Text;
            string CEP = txtCep.Text;
            string Bairro = txtBairro.Text;
            string Localidade = txtCidade.Text;
            string UF = txtEstado.Text;
            string Complemento = txtComplemento.Text;            
            string Logradouro = txtLogadouro.Text;
            string NumeroEndereco = txtNumero.Text;
            Complemento += txtComplementoApt;
            InserirCliente(Nome, CPF, NumeroEndereco, Complemento, CEP, Logradouro, Bairro, Localidade, UF);


>>>>>>> 3fa636d3d82162093ccf21c3c18b35b43b029f0a
        }
        public async Task InserirCliente(string Nome, string CPF, string NumeroEndereco, string Complemento, string CEP, string Logradouro, string Bairro, string Localidade, string UF)
        {
            var Insert = await pessoaService.InsertAsync(Nome, CPF, NumeroEndereco, Complemento, CEP, Logradouro, Bairro, Localidade, UF);
        }


        //private void txtCpfCnpj_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    Imprimi imp = new Imprimi();
        //   string txt = imp.Formatar(txtCpfCnpj.Text);

        //    ReciboJanela.Validacao val = new ReciboJanela.Validacao();


        //    if(!val.ValidarCpf(txt))
        //   {
        //       txtCpfCnpj.Text = "CPF"; 
        //   }
        //    else if (val.ValidarCnpj(txt))
        //    {
        //        txtCpfCnpj.Text = "CNPJ";
        //    }
        //}

    }

}
