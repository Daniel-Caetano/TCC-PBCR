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
           string txt = imp.Formatar(txtCpfCnpj.Text);

            ReciboJanela.Validacao val = new ReciboJanela.Validacao();


            if(txt.Length != 11)
           {
               string tmp1 = val.ValidarCpf(txt).ToString();
               // MessageBox.Show("Sucesso!! ");
           }
            else
           {
                string tmp2 = val.ValidarCnpj(txt).ToString();
                //MessageBox.Show("Derrota!! ");
            }
        }
    }
}
