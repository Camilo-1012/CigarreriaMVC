using Microsoft.AspNetCore.Mvc;
using CigarreriaMVC.AccesoDatos.Data.Repository;
using CigarreriaMVC.Models;

namespace CigarreriaMVC.Controllers
    {
    public class ProductosController : Controller
        {
        private readonly IContenedorTrabajo _ct;

        public ProductosController ( IContenedorTrabajo contenedorTrabajo )
            {
            _ct = contenedorTrabajo;
            }

        public IActionResult Index ()
            {
            var lista = _ct.Producto.GetAll();
            return View ( lista );
            }

        public IActionResult Create ()
            {
            return View ( new Producto ( ) );
            }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create ( Producto producto )
            {
            if ( !ModelState.IsValid )
                return View ( producto );

            _ct.Producto.Add ( producto );
            _ct.Save ( );
            return RedirectToAction ( nameof ( Index ) );
            }
        }
    }
