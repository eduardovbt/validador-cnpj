using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nstech.Mdm.Domain.Rules
{

    public class CheckSumRule
    {
        public static bool CnpjIsValid(string cnpj)
        {
            cnpj = new string(cnpj.Where(char.IsDigit).ToArray());

            if (cnpj.Length != 14)
                return false;

            if (cnpj.All(c => c == cnpj[0]))
                return false;

            int[] pesosPrimeiroDigito = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int somaPrimeiroDigito = 0;

            for (int i = 0; i < 12; i++)
            {
                somaPrimeiroDigito += int.Parse(cnpj[i].ToString()) * pesosPrimeiroDigito[i];
            }

            int restoPrimeiroDigito = somaPrimeiroDigito % 11;
            int primeiroDigitoVerificador = restoPrimeiroDigito < 2 ? 0 : 11 - restoPrimeiroDigito;

            if (primeiroDigitoVerificador != int.Parse(cnpj[12].ToString()))
                return false;

            int[] pesosSegundoDigito = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int somaSegundoDigito = 0;

            for (int i = 0; i < 13; i++)
            {
                somaSegundoDigito += int.Parse(cnpj[i].ToString()) * pesosSegundoDigito[i];
            }

            int restoSegundoDigito = somaSegundoDigito % 11;
            int segundoDigitoVerificador = restoSegundoDigito < 2 ? 0 : 11 - restoSegundoDigito;

            return segundoDigitoVerificador == int.Parse(cnpj[13].ToString());
        }
    }
}

