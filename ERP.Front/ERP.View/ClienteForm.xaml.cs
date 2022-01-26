﻿using System.Windows.Controls;
using System.Dynamic;
using System.Windows;

namespace ERP.View
{
    /// <summary>
    /// Interaction logic for ClienteForm.xaml
    /// </summary>
    public partial class ClienteForm : Page
    {
        public ClienteForm()
        {
            InitializeComponent();
        }

        private void txtCpfCnpj_TextChanged(object sender, TextChangedEventArgs e)
        {
            Imprimi imp = new Imprimi();
           string txt = imp.Formatar(txtCpfCnpj.Text);

            ReciboJanela.Validacao val = new ReciboJanela.Validacao();


            if(!val.ValidarCpf(txt))
           {
               txtCpfCnpj.Text = "CPF"; 
           }
            else if (val.ValidarCnpj(txt))
            {
                txtCpfCnpj.Text = "CNPJ";
            }
        }
    }
}
