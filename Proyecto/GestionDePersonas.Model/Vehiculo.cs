using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionDePersonas.Model
{
    [Table("Vehiculo")]
    [Index(nameof(Placa), IsUnique = true)]
    public class Vehiculo
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Persona")]
        public int? PersonaId { get; set; }   // FK

        [Required(ErrorMessage = "El campo Placa es requerido")]
        [StringLength(10, ErrorMessage = "La placa no debe tener más de 10 caracteres")]
        public string Placa { get; set; }

        [Required(ErrorMessage = "El campo Marca es requerido")]
        [StringLength(50)]
        public string Marca { get; set; }

        [Required(ErrorMessage = "El campo Modelo es requerido")]
        [StringLength(50)]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "El campo Año es requerido")]
        public int Anio { get; set; }
    }

}
