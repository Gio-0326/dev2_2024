using Microsoft.AspNetCore.Mvc; // using in modo da usare IActionResult
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering; // using in modo da usare SelectListItem
using _37_webapp_Sqlite.Utilities;
namespace _37_webapp_Sqlite.Models;



public class CreateFornitoreModel : PageModel
{
    // proprietà pubblica di tipo prodotto per contenere i dati del prodotto
    [BindProperty] // attributo bind property per collegare il modello al form
    public Fornitore Fornitore { get; set; }

    public IActionResult OnPost()
    {

        // controllo se il model è valido cioè se i dati inseriti dall'utente rispettano le regole di validazione
        // se il modello non e valido ritorno la pagina con gli errori
        if (!ModelState.IsValid)
        {
           
            // page è un metodo di page model che restituisce un oggetto page result che rappresenta la pagina nella quale siamo
            return Page(); // se il modello non è valido ritorno la pagina
        }

        try
        {
            DbUtils.ExecuteNonQuery(
                "INSERT INTO Fornitori (Nome) VALUES (@nome)",
                cmd =>
                {
                    cmd.Parameters.AddWithValue("@nome", Fornitore.Nome);
                }
            );
        }
        catch (Exception ex)
        {
            SimpleLogger.Log(ex);
            ModelState.AddModelError("", "Errore durante il salvataggio del fornitore.");
            return Page();
        }
        return RedirectToPage("Fornitori");
    }
}