using CigarreriaMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace CigarreriaMVC.AccesoDatos.Data
    {
    public class ApplicationDbContext : DbContext
        {
        public ApplicationDbContext ( DbContextOptions<ApplicationDbContext> options )
            : base ( options )
            {
            }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<MovimientoInventario> MovimientosInventario { get; set; }
        }
    }
