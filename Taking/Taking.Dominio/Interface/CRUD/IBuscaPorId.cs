
namespace Taking.Dominio.Interface.CRUD
{
    public interface IBuscaPorId<T> where T : class
    {
        T BuscaPorId(int id);
    }
}
