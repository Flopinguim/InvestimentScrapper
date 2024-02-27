using System.Text.RegularExpressions;

namespace Utils
{
    public static class StringExtensions
    {
        /// Verifica se a string informada é vazia ou null.
        public static bool IsEmpty(this string str) => string.IsNullOrEmpty(str);

        /// Verifica se a string informada não é vazia ou null.
        public static bool isNotEmpty(this string str) => !IsEmpty(str);

        /// <summary>
        /// Verifica se o valor informado não é um número.
        /// </summary>
        /// <param name="valor">String que será verificada.</param>
        /// <returns>True se não for número.</returns>
        public static bool isNotMatchNumber(this string valor) => Regex.IsMatch(valor, @"\D");

        /// <summary>
        /// Verifica se o valor informado é um número.
        /// </summary>
        /// <param name="valor">String que será verificada.</param>
        /// <returns>True se for número.</returns>
        public static bool isMatchNumber(this string valor) => !valor.isNotMatchNumber();

        /// <summary>
        /// Remove os números de uma string
        /// </summary>
        public static string filterNumbers(this string valor)
        {
            if (!string.IsNullOrEmpty(valor))
                return Regex.Replace(valor, @"\D", "");
            else
                return valor;
        }

        /// <summary>
        /// Retorna somente números de uma string
        /// </summary>
        public static string filterChar(this string valor) => valor.isNotEmpty() ? Regex.Replace(valor, @"[^\d]", string.Empty) : valor;

        public static string keepNumbersCommaDot(this string valor) => valor.isNotEmpty() ? Regex.Replace(valor, @"[^\d,\.]", string.Empty) : valor;

        public static decimal toDecimal(this string valor) => decimal.TryParse(valor, out decimal num) ? num : 0;
    }
}
