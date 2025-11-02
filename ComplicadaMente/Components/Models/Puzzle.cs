using System.ComponentModel.DataAnnotations;

namespace ComplicadaMente.Components.Models;

public class Puzzle
{
    
    [Key]
    public int ID_Puzzle { get; set; } // Maps the primary key in the database
    public string Nome { get; set; } // Maps the "Nome" column
    public string Tipo { get; set; } // Maps the "Tipo" column
    public decimal Preco { get; set; } // Maps the "Preco" column
    public string ImagePath { get; set; } // Maps the "ImagePath" column
}