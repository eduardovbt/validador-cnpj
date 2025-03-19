using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nstech.Mdm.Tests.Rules
{
    public class CnpjValidRule
    {
        private static int CalcularDigitoVerificador(string cnpjBase, int[] multiplicadores)
        {
            // Calcula a soma dos produtos dos números pelos multiplicadores
            int soma = cnpjBase.Select((n, i) => (n - '0') * multiplicadores[i]).Sum();
            int resto = soma % 11;

            // Retorna o dígito de verificação com base no resto
            return (resto < 2) ? 0 : 11 - resto;
        }

        // Função para gerar um CNPJ válido de 14 dígitos
        public static string GerarCnpjValido()
        {
            var random = new Random();

            // Gerar os 8 primeiros dígitos do CNPJ (Raiz do CNPJ)
            var cnpjBase = string.Concat(Enumerable.Range(0, 12).Select(_ => random.Next(0, 10)));

            // Definir os multiplicadores para o primeiro e segundo dígitos verificadores
            int[] multiplicadores1 = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };  // Para o primeiro dígito
            int[] multiplicadores2 = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };  // Para o segundo dígito

            // Calcular o primeiro dígito verificador
            int primeiroDigito = CalcularDigitoVerificador(cnpjBase, multiplicadores1);

            // Adicionar o primeiro dígito verificador à base do CNPJ
            var cnpjComPrimeiroDigito = cnpjBase + primeiroDigito;

            // Calcular o segundo dígito verificador
            int segundoDigito = CalcularDigitoVerificador(cnpjComPrimeiroDigito, multiplicadores2);

            // Montar o CNPJ completo de 14 dígitos
            return $"{cnpjBase}{primeiroDigito}{segundoDigito}";
        }
    }
}
