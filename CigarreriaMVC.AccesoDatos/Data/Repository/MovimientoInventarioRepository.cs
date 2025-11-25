using System.Collections.Generic;
using System.Linq;
using CigarreriaMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CigarreriaMVC.AccesoDatos.Data.Repository
    {
    public class MovimientoInventarioRepository
        : Repository<MovimientoInventario>, IMovimientoInventarioRepository
        {
        private readonly ApplicationDbContext _db;

        public MovimientoInventarioRepository ( ApplicationDbContext db ) : base ( db )
            {
            _db = db;
            }

        public IEnumerable<MovimientoInventario> ObtenerUltimos ( int cantidad )
            {
            return _db.MovimientosInventario
                      .Include ( m => m.Producto )
                      .OrderByDescending ( m => m.Fecha )
                      .ThenByDescending ( m => m.Id )
                      .Take ( cantidad )
                      .ToList ( );
            }
        }
    }
