using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcExamenFinalJor.Models
{
    [Table("categoriaevento")]
    public class Categoria
    {
        [Key]
        [Column("idcategoria")]
        public int IdCategoria { get; set; }

        [Column("nombre")]
        public string Nombre { get; set; }
    }
}
