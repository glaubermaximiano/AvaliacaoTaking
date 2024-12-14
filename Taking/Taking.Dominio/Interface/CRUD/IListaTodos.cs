
namespace Taking.Dominio.Interface.CRUD
{
    public interface IListaTodos<T> where T : class
    {
        List<T> ListaTodos(string idcSituacao);
    }
}
