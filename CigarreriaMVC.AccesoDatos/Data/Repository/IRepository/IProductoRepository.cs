using CigarreriaMVC.Models;

namespace CigarreriaMVC.AccesoDatos.Data.Repository
    {
    public interface IProductoRepository : IRepository<Producto>
        {
        void Actualizar ( Producto producto );
        }
    }
