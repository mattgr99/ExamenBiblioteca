//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BEUBiblioteca
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Video
    {
        [ScaffoldColumn(false)]
        public int idvideo { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El título es requerido"), MaxLength(55)]
        [Display(Name = "Título Video")]
        public string titulo { get; set; }

        [Display(Name = "Fecha Publicación")]
        [DisplayFormat(DataFormatString = "{0:dd/MMM/yyyy}")]
        [DataType(DataType.Date)]
        public Nullable<System.DateTime> fecha_publ { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "El formato es requerido"), MaxLength(50)]
        [Display(Name = "Formato Video")]
        public string formato { get; set; }

        [DataType(DataType.Duration)]
        [Required(ErrorMessage = "Duración requerida")]
        [Display(Name = "Duración(minutos)")]
        public Nullable<int> duracion { get; set; }

        [Required(ErrorMessage = "La categoría es requerida")]
        [Display(Name = "Categoría")]
        public Nullable<int> idcategoria { get; set; }
    
        public virtual Categoria Categoria { get; set; }
    }
}
