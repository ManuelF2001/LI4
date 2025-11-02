using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComplicadaMente.Components.Models
{
    public class Encomenda
    {
        [Key]
        public int ID_Encomenda { get; set; }

        [Required]
        public DateTime Data_Encomenda { get; set; } = DateTime.Now;

        [Required]
        [StringLength(50)]
        public string Status { get; set; }

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Preco_Total { get; set; }

        [Required]
        public int ID_Cliente { get; set; }

        public int? ID_Funcionario { get; set; }

        [ForeignKey("ID_Cliente")]
        public Cliente Cliente { get; set; }

        [ForeignKey("ID_Funcionario")]
        public Funcionario Funcionario { get; set; }
        public ICollection<EncomendaPuzzle> EncomendaPuzzle { get; set; }
    }
}
