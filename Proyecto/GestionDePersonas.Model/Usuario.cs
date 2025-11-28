using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionDePersonas.Model
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Cedula es requerido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El campo Cedula es requerido")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "El campo Cedula es requerido")]
        public string Contrasena { get; set; }
    }
}
