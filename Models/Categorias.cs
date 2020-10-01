using System;
using System.ComponentModel.DataAnnotations;

namespace Victor_P1_AP2.Models
{
    public class Categorias{
        [Key]
        public int CategoriaId { get; set; }

        [Required(ErrorMessage ="La descripción es obligatoria")]
         public string Descripcion { get; set; }

    }
    public class CategoriasDetalle
    {
        [Key]
        public int  Id { get; set; } 
        public int CategoriaId { get; set; }
    }

}