using System.Linq;
using CigarreriaMVC.Models;

namespace CigarreriaMVC.AccesoDatos.Data.Repository
    {
    public class ProductoRepository : Repository<Producto>, IProductoRepository
        {
        private readonly ApplicationDbContext _db;

        public ProductoRepository ( ApplicationDbContext db ) : base ( db )
            {
            _db = db;
            }

        public void Actualizar ( Producto producto )
            {
            var obj = _db.Productos.FirstOrDefault(p => p.Id == producto.Id);
            if ( obj != null )
                {
                obj.CodigoBarra = producto.CodigoBarra;
                obj.Nombre = producto.Nombre;
                obj.Categoria = producto.Categoria;
                obj.PrecioCompra = producto.PrecioCompra;
                obj.PrecioVenta = producto.PrecioVenta;
                obj.StockActual = producto.StockActual;
                obj.StockMinimo = producto.StockMinimo;
                obj.Activo = producto.Activo;
                }
            }
        }
    }
