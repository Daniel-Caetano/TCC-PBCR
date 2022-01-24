using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ReciboJanela
{
    public class Validacao : Dados
    {
        public static bool ValidarCnpj(string cnpj)
        {
            //números que serão utilizados para calcular o primeiro e segundo dígito que valida se o CNPJ é ou não valido
            int[] fator1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] fator2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            //verifica se o CNPJ tem 14 digitos
            if (cnpj.Length != 14)
            {
                return false;
            }
            else
            {
                for (int i = 0; i < cnpj.Length; i++)
                {
                    if (!Char.IsDigit(cnpj[i]))
                    {
                        return false;
                    }
                }
            }
            //calcula o primeiro dígito do CNPJ
            int soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(cnpj[i].ToString()) * fator1[i];

            int resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            string digito = resto.ToString();

            //calcula o segundo dígito do CNPJ
            if (digito == cnpj[12].ToString())
            {
                soma = 0;

                for (int i = 0; i < 13; i++)
                    soma += int.Parse(cnpj[i].ToString()) * fator2[i];
                resto = soma % 11;

                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;

                digito += resto.ToString();

                return cnpj.EndsWith(digito);
            }
            else

                return true;
        }
        public static bool ValidarCpf(string cpf)
        {
            //validar cpf
            bool cpfValido = true;
            //verifica se o cpf tem 11 dígitos
            if (cpf.Length != 11)
            {
                cpfValido = false;
                // MessageBox.Show("O CPF informado não e valido");
            }
            else
            {    //verifica se todos os caracteres de cpf são digitos numéricos
                for (int i = 0; i < cpf.Length; i++)
                {
                    if (!Char.IsDigit(cpf[i]))
                    {
                        cpfValido = false;
                        MessageBox.Show("O CPF informado não e valido");
                        break;
                    }
                }

            }

            //verifica se é 00000000000...99999999999
            if (cpfValido)
            {
                for (byte i = 0; i < 10; i++)
                {
                    var temp = new string(Convert.ToChar(i), 11);
                    if (cpf == temp)
                    {
                        cpfValido = false;
                        //  MessageBox.Show("O CPF informado não e valido");
                        break;
                    }
                }

            }
            //Verificar dígito de controle do cpf
            if (cpfValido)
            {
                var j = 0;
                var digVerificador1 = 0;
                var digVerificador2 = 0;
                //Validar o primeiro numero do dígito de controle
                for (int i = 10; i > 1; i--)
                {
                    digVerificador1 += Convert.ToInt32(cpf.Substring(j, 1)) * i;
                    j++;
                }
                //resto de divisão
                digVerificador1 = (digVerificador1 * 10) % 11;
                if (digVerificador1 == 10)
                {
                    digVerificador1 = 0;
                }
                //Verifica se o primeiro número cnvergiu com a posição 9 (penultima)
                if (digVerificador1 != Convert.ToInt32(cpf.Substring(9, 1)))
                {
                    cpfValido = false;
                    //  MessageBox.Show("O CPF informado não e valido");
                }
                //valida o segundo número (dígito) de controle
                if (cpfValido)
                {
                    j = 0;
                    for (int i = 11; i > 1; i--)
                    {
                        digVerificador2 += Convert.ToInt32(cpf.Substring(j, 1)) * i;
                        j++;
                    }
                    //resto da divisão
                    digVerificador2 = (digVerificador2 * 10) % 11;
                    if (digVerificador2 == 10)
                    {
                        digVerificador2 = 0;
                    }
                    //verifica se o segundo dígito convergiu com o caractere 10 (última)
                    if (digVerificador2 != Convert.ToInt32(cpf.Substring(10, 1)))
                    {
                        cpfValido = false;
                        // MessageBox.Show("O CPF informado não e valido");
                    }

                }
            }
            return cpfValido;
        }
        public static string RetirarMascara(string mascara)
        {
            return mascara.Trim().Replace(".", "").Replace("-", "").Replace("/", "");
        }
    }
      
}

    

