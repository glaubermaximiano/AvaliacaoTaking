
namespace Taking.Dominio.Interface.CRUD.Servico
{
    public interface IUpdateServico<T> where T : class
    {
        string Update(T obj);
    }
}
