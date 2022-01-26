using System.Windows.Controls;
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
        }
    }
}
