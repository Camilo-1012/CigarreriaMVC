using System.Collections.Generic;
using CigarreriaMVC.Models;

namespace CigarreriaMVC.AccesoDatos.Data.Repository
    {
    public interface IMovimientoInventarioRepository : IRepository<MovimientoInventario>
        {
        IEnumerable<MovimientoInventario> ObtenerUltimos ( int cantidad );
        }
    }
