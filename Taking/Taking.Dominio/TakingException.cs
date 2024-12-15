using System.Diagnostics.CodeAnalysis;

namespace Taking.Dominio
{
    [ExcludeFromCodeCoverage]
    public class TakingException : Exception
    {
        public TakingException(string msg)
           : base(msg) { }
    }
}
