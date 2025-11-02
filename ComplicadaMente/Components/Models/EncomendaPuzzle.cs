using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComplicadaMente.Components.Models
{

    [Table("Encomenda_Puzzle")]
    public class EncomendaPuzzle
    {
        [Key, Column(Order = 0)]
        public int ID_Encomenda { get; set; }

        [Key, Column(Order = 1)]
        public int ID_Puzzle { get; set; }

        [Required]
        public int Quantidade { get; set; } = 1;

        [ForeignKey("ID_Encomenda")]
        public Encomenda Encomenda { get; set; }

        [ForeignKey("ID_Puzzle")]
        public Puzzle Puzzle { get; set; }
    }
}
