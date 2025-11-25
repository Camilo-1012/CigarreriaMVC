using Microsoft.AspNetCore.Mvc;
using CigarreriaMVC.AccesoDatos.Data.Repository;
using CigarreriaMVC.Models;

namespace CigarreriaMVC.Areas.Admin.Controllers
    {
    [Area ( "Admin" )]
    public class ProductoController : Controller
        {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        public ProductoController ( IContenedorTrabajo contenedorTrabajo )
            {
            _contenedorTrabajo = contenedorTrabajo;
            }

        // GET: /Admin/Producto
        [HttpGet]
        public IActionResult Index ()
            {
            // La vista Index normalmente solo carga el DataTable vía AJAX
            return View ( );
            }

        // GET: /Admin/Producto/Create
        [HttpGet]
        public IActionResult Create ()
            {
            return View ( new Producto ( ) );
            }

        // POST: /Admin/Producto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create ( Producto producto )
            {
            if ( !ModelState.IsValid )
                return View ( producto );

            _contenedorTrabajo.Producto.Add ( producto );
            _contenedorTrabajo.Save ( );

            return RedirectToAction ( nameof ( Index ) );
            }

        // GET: /Admin/Producto/Edit/5
        [HttpGet]
        public IActionResult Edit ( int id )
            {
            var producto = _contenedorTrabajo.Producto.Get(id);
            if ( producto == null )
                return NotFound ( );

            return View ( producto );
            }

        // POST: /Admin/Producto/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit ( Producto producto )
            {
            if ( !ModelState.IsValid )
                return View ( producto );

            _contenedorTrabajo.Producto.Actualizar ( producto );
            _contenedorTrabajo.Save ( );

            return RedirectToAction ( nameof ( Index ) );
            }

        #region API

        // GET: /Admin/Producto/GetAll
        [HttpGet]
        public IActionResult GetAll ()
            {
            var lista = _contenedorTrabajo.Producto.GetAll();
            return Json ( new { data = lista } );
            }

        // DELETE: /Admin/Producto/Delete/5
        [HttpDelete]
        public IActionResult Delete ( int id )
            {
            var objFromDb = _contenedorTrabajo.Producto.Get(id);
            if ( objFromDb == null )
                {
                return Json ( new
                    {
                    success = false ,
                    message = "Error borrando el producto"
                    } );
                }

            _contenedorTrabajo.Producto.Remove ( objFromDb );
            _contenedorTrabajo.Save ( );

            return Json ( new
                {
                success = true ,
                message = "Producto eliminado correctamente"
                } );
            }

        #endregion
        }
    }
