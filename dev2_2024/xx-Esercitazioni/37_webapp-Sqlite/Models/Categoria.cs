using System.ComponentModel.DataAnnotations;
namespace _37_webapp_Sqlite.Models;
public class Categoria
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Il nome della categoria è obbligatorio.")] // se non mettiamo niente si ferma, è necessario metterci un ErrorMessage
    [StringLength(100, ErrorMessage = "Il nome non può superare i 100 caratteri.")] // se supera più di 100 caratteri da errore
    public string Nome { get; set; }
    
}