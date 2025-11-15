using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace GestionDePersonas.Model
{
    [Table("Persona")]
    public class Persona
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo Cedula es requerido")]
        public int Cedula { get; set; }

        [Required(ErrorMessage = "El campo Nombre es requerido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El campo Edad es requerido")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "El campo Teléfono es requerido")]
        public int Telefono { get; set; }

        [Required(ErrorMessage = "El campo Teléfono es requerido")]
        public double salario { get; set; }

    }
}
