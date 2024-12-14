
namespace Taking.Dominio.Interface.CRUD.Servico
{
    public interface IAddRServico<T> where T : class
    {
        int Add(T obj);
    }
}
