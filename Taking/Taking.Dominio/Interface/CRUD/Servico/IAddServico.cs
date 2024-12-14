
namespace Taking.Dominio.Interface.CRUD.Servico
{
    public interface IAddServico<T> where T : class
    {
        string Add(T obj);
    }
}
