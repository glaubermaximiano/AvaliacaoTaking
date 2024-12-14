
namespace Taking.Aplicacao.Interface.CRUD
{
    public interface IAppServiceRemoveObj<T> where T : class
    {
        string Remove(T obj);
    }
}
