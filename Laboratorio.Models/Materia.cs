using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Laboratorio.Models
{
    public class Materia : EntityBase
    {
        [Required(ErrorMessage = "El campo codigo no puede quedar vacio")]
        [MinLength(2, ErrorMessage = "El campo de materia debe tener minimo 2 caracteres")]
        [MaxLength(10, ErrorMessage = "El campo de materia debe tener maximo 10 caracteres")]
        [Display(Name = "Codigo de materia")]
        public string Codigo { get; set; }
        [Required(ErrorMessage = "El Nombre codigo no puede quedar vacio")]
        [MinLength(3, ErrorMessage = "El campo de materia debe tener minimo 3 caracteres")]
        [MaxLength(25, ErrorMessage = "El campo de materia debe tener maximo 25 caracteres")]
        [Display(Name = "Nombre de materia")]
        public string Descripcion { get; set; }
        public bool Habilitada { get; set; }
    }
}

