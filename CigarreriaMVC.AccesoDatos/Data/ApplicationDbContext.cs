using CigarreriaMVC.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
    {
    public ApplicationDbContext ( DbContextOptions<ApplicationDbContext> options )
        : base ( options )
        {
        }

    public DbSet<Producto> Productos { get; set; }
    public DbSet<MovimientoInventario> MovimientosInventario { get; set; }
    }
