using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogCore.Models
{
    public class Articulo
    {
        [Key] 
        public int Id { get; set; }
        
        [Required(ErrorMessage ="El Nombre es obligatorio")]
        [Display(Name ="Nombre del Articulo")]
        public string Nombre { get; set; }

        [Required(ErrorMessage ="La Descripcíon es obligatoria")]
        public string Descripcion { get; set; }
        
        [Display(Name ="Fecha de creacíon")]
        public string FechaCreacion { get; set; }

        [DataType(DataType.ImageUrl)]
        [Display(Name ="Imagen")]
        public string UrlImage { get; set; }

        [Required]
        public int CategoriaId { get; set; }
        //esto es para relacionar el articulo con una categoria
        [ForeignKey("CategoriaId")]
        public Categoria Categoria { get; set; }
    }
}
