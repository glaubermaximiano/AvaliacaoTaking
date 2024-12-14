
namespace Taking.Aplicacao.Interface.CRUD
{
    public interface IAppServiceAdd<T> where T : class
    {
        string Add(T obj);
    }
}
