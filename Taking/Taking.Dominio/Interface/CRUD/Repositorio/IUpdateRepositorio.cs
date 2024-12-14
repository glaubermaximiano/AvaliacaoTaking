
namespace Taking.Dominio.Interface.CRUD.Repositorio
{
    public interface IUpdateRepositorio<T> where T : class
    {
        void Update(T obj);
    }
}
