using Microsoft.AspNetCore.Mvc; // using in modo da usare IActionResult
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering; // using in modo da usare SelectListItem
using System.Data.SQLite;
using _37_webapp_Sqlite.Utilities;
namespace _37_webapp_Sqlite.Models;
public class CreateCategoriaModel : PageModel
{
    // proprietà pubblica di tipo Categoria per contenere i dati della categoria
    [BindProperty]  // attributo bind property per collegare il modello al form
    public Categoria Categoria { get; set; }

    public IActionResult OnPost()
    {
        // controllo se il model è valido cioè se i dati inseriti dall'utente rispettano le regole di validazione
        // se il modello non e valido ritorno la pagina con gli errori
        if (!ModelState.IsValid)
        {
            return Page();
        }

        try
        {
            DbUtils.ExecuteNonQuery(
                "INSERT INTO Categorie (Nome) VALUES (@nome)",
                cmd =>
                {
                    cmd.Parameters.AddWithValue("@nome", Categoria.Nome);
                }
            );
        }
        catch (Exception ex)
        {
            SimpleLogger.Log(ex);
            ModelState.AddModelError("", "Errore durante il salvataggio della categoria.");
            return Page();
        }
        return RedirectToPage("Categorie");
    }
}
/* invoco il metodo GetConnection per ottenere la connessione al db
using var connection = DatabaseInitializer.GetConnection();
// apro la connessione
connection.Open();

// Verifico se esiste già una categoria con lo stesso nome
var checkSql = "SELECT COUNT(1) FROM Categorie WHERE Nome = @nome"; // Conta quante righe nella tabella 'Categorie' hanno un 'Nome' uguale al parametro @nome
using var checkCommand = new SQLiteCommand(checkSql, connection);
checkCommand.Parameters.AddWithValue("@nome", Categoria.Nome);

// dato che count di sql è un valore numerico, posso usare execute scalar per ottenere il valore
// execute scalar ritorna un oggetto quindi faccio il casting a long per ottenere il valore numerico
var count = (long)checkCommand.ExecuteScalar();

if (count > 0) // se il count è maggiore a zero, allora esiste già una categoria con lo stesso nome nel db 
{
    // Aggiungo un errore di validazione se la categoria esiste già
    // ModelState è un oggetto che contiene gli errori di validazione per il modello corrente (nel contesto di una pagina o di un form).
    // AddModelError è un metodo in ASP.NET (sia MVC che Razor Pages) che permette di aggiungere un errore di validazione al ModelState.
    ModelState.AddModelError("Categoria.Nome", "La categoria con questo nome esiste già.");
    return Page();
}

// creo la query sql per inserire un nuova categoria usando i parametri
var sql = "INSERT INTO Categorie (Nome) VALUES (@nome)";
// creo un comando sql per eseguire la query
using var command = new SQLiteCommand(sql, connection);
// aggiungo i parametri al comando con il metodo add with value che prende il nome del parametro e il valore
command.Parameters.AddWithValue("@nome", Categoria.Nome);
// eseguo il comando
command.ExecuteNonQuery();
// reinderizzo l'utente alla pagina di elenco delle categorie
return RedirectToPage("Categorie");*/

