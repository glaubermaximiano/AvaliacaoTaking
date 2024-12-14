using System.Diagnostics.CodeAnalysis;

namespace Taking.Aplicacao
{
    [ExcludeFromCodeCoverage]
    public abstract class Taking
    {

        protected void TrataErro(string msgErro)
        {
            NLog.LogManager.GetLogger("fileTarget").Error(msgErro);
        }
    }
}
