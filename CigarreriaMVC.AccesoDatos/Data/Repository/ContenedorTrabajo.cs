namespace CigarreriaMVC.AccesoDatos.Data.Repository
    {
    public class ContenedorTrabajo : IContenedorTrabajo
        {
        private readonly ApplicationDbContext _db;

        public ContenedorTrabajo ( ApplicationDbContext db )
            {
            _db = db;

            Producto = new ProductoRepository ( _db );
            MovimientoInventario = new MovimientoInventarioRepository ( _db );
            }

        public IProductoRepository Producto { get; private set; }
        public IMovimientoInventarioRepository MovimientoInventario { get; private set; }

        public void Save ()
            {
            _db.SaveChanges ( );
            }

        public void Dispose ()
            {
            _db.Dispose ( );
            }
        }
    }
