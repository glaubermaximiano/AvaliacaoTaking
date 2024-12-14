
namespace Taking.Dominio.Interface.CRUD.Repositorio
{
    public interface IAddRepositorio<T> where T : class
    {
        void Add(T obj);
    }
}
