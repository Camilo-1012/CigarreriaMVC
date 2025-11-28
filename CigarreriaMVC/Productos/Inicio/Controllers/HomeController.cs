using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CigarreriaMVC.Models;

namespace CigarreriaMVC.Inicio.Controllers
    {
    [Area ( "Inicio" )]
    public class HomeController : Controller
        {
        // GET: /Inicio/Home/Index  (ruta por defecto si configuraste el área)
        public IActionResult Index ()
            {
            // Simplemente devuelve la vista del panel principal
            return View ( );
            }

        // GET: /Inicio/Home/Privacy
        public IActionResult Privacy ()
            {
            return View ( );
            }

        // Manejador de errores estándar (opcional, pero recomendable)
        [ResponseCache ( Duration = 0 , Location = ResponseCacheLocation.None , NoStore = true )]
        public IActionResult Error ()
            {
            return View ( new ErrorViewModel
                {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
                } );
            }
        }
    }
