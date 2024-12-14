
namespace Taking.Dominio.Interface.CRUD.Repositorio
{
    public interface IAddRRepositorio<T> where T : class
    {
        int Add(T obj);
    }
}
