using System;

namespace CigarreriaMVC.AccesoDatos.Data.Repository
    {
    public interface IContenedorTrabajo : IDisposable
        {
        IProductoRepository Producto { get; }
        IMovimientoInventarioRepository MovimientoInventario { get; }

        void Save ();
        }
    }
