using System.ComponentModel.DataAnnotations;

namespace ComplicadaMente.Components.Models;

public class Cliente
{
    
    [Key]
    public int ID_Cliente{ get; set; }
    
    
    [Required(ErrorMessage = "Nome is required")]
    public string Nome { get; set; }
    
    [Required(ErrorMessage = "Email is required")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "Telefone is required")]
    public string Telefone { get; set; }
    
    [Required(ErrorMessage = "Morada is required")]
    public string Morada { get; set; }
    
    [Required(ErrorMessage = "Passe is required")]
    public string Passe { get; set; }
    
}