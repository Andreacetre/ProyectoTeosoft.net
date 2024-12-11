using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeoSoft.Models
{
    public class Venta
    {
        [Key]
        public int VentaId { get; set; }

        [Required(ErrorMessage = "La fecha de la venta es obligatoria.")]
<<<<<<< HEAD
        [Display(Name = "Fecha de Venta")]
        [DataType(DataType.Date)]
=======
>>>>>>> 0e435cdc8c2b25949ae51caa606b9e1b13608482
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "El total es obligatorio.")]
        [Range(0.01, 999999.99, ErrorMessage = "El total debe ser mayor a 0 y menor a 1,000,000.")]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Total")]
        public decimal Total { get; set; }

<<<<<<< HEAD
        [Required(ErrorMessage = "El cliente es obligatorio.")]
        [Display(Name = "Cliente")]
        public int ClienteId { get; set; }

        [ForeignKey("ClienteId")]
        public Cliente Cliente { get; set; }

        [Required(ErrorMessage = "El producto es obligatorio.")]
        [Display(Name = "Producto")]
        public int IdProducto { get; set; }

        [ForeignKey("IdProducto")]
        public Producto Producto { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio.")]
        [Display(Name = "Estado")]
        [RegularExpression("^(Pendiente|Completada|Anulada)$", ErrorMessage = "El estado debe ser 'Pendiente', 'Completada' o 'Anulada'.")]
        public string Estado { get; set; }

        public List<DetalleVenta> DetalleVenta { get; set; } = new List<DetalleVenta>();

=======
        [Required(ErrorMessage = "El ID del cliente es obligatorio.")]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "El cliente es obligatorio.")]
        public Cliente Cliente { get; set; }

        [Required(ErrorMessage = "El ID del producto es obligatorio.")]
        public int IdProducto { get; set; }

        [Required(ErrorMessage = "El producto es obligatorio.")]
        public Producto Producto { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio.")]
        [RegularExpression("^(pendiente|pagado|cancelado)$", ErrorMessage = "El estado debe ser 'pendiente', 'pagado' o 'cancelado'.")]
        public string Estado { get; set; }

        // Relación con detalles de la venta
        public List<DetalleVenta> DetalleVenta { get; set; } = new List<DetalleVenta>();

        // Relación con devoluciones
>>>>>>> 0e435cdc8c2b25949ae51caa606b9e1b13608482
        public ICollection<Devolucion> Devoluciones { get; set; }
    }
}
