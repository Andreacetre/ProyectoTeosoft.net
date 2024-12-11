using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeoSoft.Models
{
    public class Producto
    {
        [Key]
        public int ProductoId { get; set; }

        [Required(ErrorMessage = "El código de barra es obligatorio.")]
        [StringLength(50, ErrorMessage = "El código de barra no puede exceder los 50 caracteres.")]
<<<<<<< HEAD
        [Display(Name = "Código de Barra")]
=======
>>>>>>> 0e435cdc8c2b25949ae51caa606b9e1b13608482
        public string CodigoDeBarra { get; set; }

        [Required(ErrorMessage = "El nombre del producto es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio.")]
        [Range(0.01, 999999.99, ErrorMessage = "El precio debe ser mayor que 0 y menor que 1,000,000.")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "El stock es obligatorio.")]
        [Range(0, int.MaxValue, ErrorMessage = "El stock debe ser un valor positivo.")]
        public int Stock { get; set; }

        [StringLength(500, ErrorMessage = "La descripción no puede exceder los 500 caracteres.")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El IVA es obligatorio.")]
        [Range(0, 100, ErrorMessage = "El IVA debe estar entre 0 y 100.")]
        public double IVA { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Vencimiento")]
        public DateTime? FechaVencimiento { get; set; }

        [Required(ErrorMessage = "Debe indicar si el producto no tiene vencimiento.")]
<<<<<<< HEAD
        [Display(Name = "Sin Vencimiento")]
=======
>>>>>>> 0e435cdc8c2b25949ae51caa606b9e1b13608482
        public bool SinVencimiento { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio.")]
        [RegularExpression("^(Activo|Inactivo)$", ErrorMessage = "El estado debe ser 'Activo' o 'Inactivo'.")]
        public string Estado { get; set; } = "Activo";

        [Required(ErrorMessage = "La categoría del producto es obligatoria.")]
<<<<<<< HEAD
        [Display(Name = "Categoría")]
        public int CategoriaProductoId { get; set; }

        [ForeignKey("CategoriaProductoId")]
=======
        public int CategoriaProductoId { get; set; }

        [Required(ErrorMessage = "La categoría del producto es obligatoria.")]
>>>>>>> 0e435cdc8c2b25949ae51caa606b9e1b13608482
        public CategoriaProducto CategoriaProducto { get; set; }

        // Relaciones
        public ICollection<DetalleVenta> DetalleVentas { get; set; }
        public ICollection<DetallePedido> DetallePedidos { get; set; }
        public ICollection<Devolucion> Devoluciones { get; set; }
<<<<<<< HEAD

        internal object FirstOrDefault(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }
    }
}
=======
    }
}
>>>>>>> 0e435cdc8c2b25949ae51caa606b9e1b13608482
