using System.ComponentModel.DataAnnotations; 
namespace _37_webapp_Sqlite.Models;
public class Fornitore
{
    public int Id { get; set; } // Identificatore univoco del fornitore
    [Required(ErrorMessage = "Il nome del fornitore è obbligatorio.")]
    [StringLength(100, ErrorMessage = "Il nome non può superare i 100 caratteri.")]
    public string Nome { get; set; } // Nome del fornitore
}
