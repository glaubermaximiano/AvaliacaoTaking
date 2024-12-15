using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace Taking.Dominio.Helper
{
    [ExcludeFromCodeCoverage]
    public static class UtilHelper
    {
        public static string SomenteNumero(string vlr)
           => Regex.Replace(vlr, "[^0-9]", string.Empty);
    }
}
