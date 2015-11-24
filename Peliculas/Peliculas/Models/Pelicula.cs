using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Peliculas.Models
{
    public enum Genero
    {
        [Display(Name = "Ciencia Ficcion")]
        Ficcion,
        [Display(Name = "Drama")]
        Drama,
        [Display(Name = "Comedia")]
        Comedia
    }

    public class Pelicula
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
    
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name ="Nombre de la pelicula")]
        [StringLength(50,MinimumLength = 4,ErrorMessage = "El {0} debe ser minimo {2} y maximo {1}")]
        public string Nombre { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString  ="{0:yyyy-MM-dd}",ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }

        [StringLength(500, MinimumLength = 0, ErrorMessage = "El {0} debe ser menos de {1} caracteres")]
        public string Descripcion { get; set; }

        public Genero? Categoria { get; set; }

        public string ruta { get; set; }

        [Display(Name = "Calificación")]
        public int Rate { get; set; }



    }
}