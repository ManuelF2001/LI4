using System.ComponentModel.DataAnnotations;

namespace ComplicadaMente.Components.Models
{
    public class Funcionario
    {
        [Key]
        public int ID_Funcionario { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [StringLength(50)]
        public string Cargo { get; set; }

        [Required]
        [StringLength(75)]
        public string Email { get; set; }

        [Required]
        [StringLength(75)]
        public string Passe { get; set; }

        [Required]
        public int Salario { get; set; }
    }
}
