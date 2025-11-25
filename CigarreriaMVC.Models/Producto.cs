using System.ComponentModel.DataAnnotations;

namespace CigarreriaMVC.Models
    {
    public class Producto
        {
        public int Id { get; set; }

        [Display ( Name = "Código de barra" )]
        public string? CodigoBarra { get; set; }

        [Required]
        [StringLength ( 100 )]
        public string Nombre { get; set; }

        public string? Categoria { get; set; }

        [Display ( Name = "Precio compra" )]
        [Range ( 0 , 999999 )]
        public decimal PrecioCompra { get; set; }

        [Display ( Name = "Precio venta" )]
        [Range ( 0 , 999999 )]
        public decimal PrecioVenta { get; set; }

        [Display ( Name = "Stock actual" )]
        public int StockActual { get; set; }

        [Display ( Name = "Stock mínimo" )]
        public int StockMinimo { get; set; }

        public bool Activo { get; set; } = true;
        }
    }
