using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using CigarreriaMVC.AccesoDatos.Data.Repository;
using CigarreriaMVC.Models;

namespace CigarreriaMVC.Areas.Admin.Controllers
    {
    [Area ( "Admin" )]
    public class MovimientosInventarioController : Controller
        {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        public MovimientosInventarioController ( IContenedorTrabajo contenedorTrabajo )
            {
            _contenedorTrabajo = contenedorTrabajo;
            }

        // GET: /Admin/MovimientosInventario
        [HttpGet]
        public IActionResult Index ()
            {
            return View ( );
            }

        // GET: /Admin/MovimientosInventario/Create
        [HttpGet]
        public IActionResult Create ()
            {
            CargarCombos ( );
            return View ( new MovimientoInventario ( ) );
            }

        // POST: /Admin/MovimientosInventario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create ( MovimientoInventario movimiento )
            {
            if ( !ModelState.IsValid )
                {
                CargarCombos ( );
                return View ( movimiento );
                }

            var producto = _contenedorTrabajo.Producto.Get(movimiento.ProductoId);
            if ( producto == null )
                {
                ModelState.AddModelError ( string.Empty , "Producto no encontrado." );
                CargarCombos ( );
                return View ( movimiento );
                }

            movimiento.Fecha = DateTime.Now;

            if ( movimiento.Tipo == "Entrada" )
                {
                producto.StockActual += movimiento.Cantidad;
                }
            else if ( movimiento.Tipo == "Salida" )
                {
                if ( producto.StockActual < movimiento.Cantidad )
                    {
                    ModelState.AddModelError ( string.Empty , "No hay stock suficiente para la salida." );
                    CargarCombos ( );
                    return View ( movimiento );
                    }

                producto.StockActual -= movimiento.Cantidad;
                }
            else
                {
                ModelState.AddModelError ( string.Empty , "Tipo de movimiento no válido." );
                CargarCombos ( );
                return View ( movimiento );
                }

            _contenedorTrabajo.MovimientoInventario.Add ( movimiento );
            _contenedorTrabajo.Producto.Actualizar ( producto );
            _contenedorTrabajo.Save ( );

            return RedirectToAction ( nameof ( Index ) );
            }

        // GET: /Admin/MovimientosInventario/Edit/5
        [HttpGet]
        public IActionResult Edit ( int id )
            {
            var movimiento = _contenedorTrabajo.MovimientoInventario
                .GetFirstOrDefault(m => m.Id == id);

            if ( movimiento == null )
                return NotFound ( );

            CargarCombos ( );
            return View ( movimiento );
            }

        // POST: /Admin/MovimientosInventario/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit ( MovimientoInventario movimiento )
            {
            if ( !ModelState.IsValid )
                {
                CargarCombos ( );
                return View ( movimiento );
                }

            // Obtenemos el movimiento desde la BD
            var movDb = _contenedorTrabajo.MovimientoInventario.Get(movimiento.Id);
            if ( movDb == null )
                {
                return NotFound ( );
                }

            // Solo permitimos cambiar la observación para no dañar el stock
            movDb.Observacion = movimiento.Observacion;

            _contenedorTrabajo.Save ( );

            return RedirectToAction ( nameof ( Index ) );
            }

        #region API

        [HttpGet]
        public IActionResult GetAll ()
            {
            var lista = _contenedorTrabajo.MovimientoInventario
                .GetAll(includeProperties: "Producto");

            return Json ( new { data = lista } );
            }

        #endregion

        #region Métodos privados

        private void CargarCombos ()
            {
            var productos = _contenedorTrabajo.Producto.GetAll(p => p.Activo);
            ViewBag.ProductoId = new SelectList ( productos , "Id" , "Nombre" );

            ViewBag.Tipos = new List<string> { "Entrada" , "Salida" };
            }

        #endregion
        }
    }
