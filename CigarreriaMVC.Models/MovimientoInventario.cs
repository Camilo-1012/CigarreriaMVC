using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CigarreriaMVC.Models
    {
    public class MovimientoInventario
        {
        public int Id { get; set; }

        [Display ( Name = "Producto" )]
        public int ProductoId { get; set; }

        [ForeignKey ( "ProductoId" )]
        public Producto Producto { get; set; }

        public DateTime Fecha { get; set; } = DateTime.Now;

        [Required]
        public string Tipo { get; set; }  // "Entrada" o "Salida"

        [Range ( 1 , 999999 )]
        public int Cantidad { get; set; }

        public string? Observacion { get; set; }
        }
    }
