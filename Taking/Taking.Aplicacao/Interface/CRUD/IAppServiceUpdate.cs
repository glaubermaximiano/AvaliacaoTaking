
namespace Taking.Aplicacao.Interface.CRUD
{
    public interface IAppServiceUpdate<T> where T : class
    {
        string Update(T obj);
    }
}
