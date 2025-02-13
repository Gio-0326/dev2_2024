using Microsoft.AspNetCore.Mvc; // using in modo da usare IActionResult
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering; // using in modo da usare SelectListItem
using System.Data.SQLite;

public class CreateModel : PageModel
{
    // proprietà pubblica di tipo prodotto per contenere i dati del prodotto
    [BindProperty] // attributo bind property per collegare il modello al form
    public Prodotto Prodotto { get; set; }

    // creo una lista di select list item per contenere le categorie
    // select list item è un oggetto che rappresenta un elemento di una select list
    public List<SelectListItem> CategorieSelectList { get; set; } = new List<SelectListItem>();

    public void OnGet()
    {
        CaricaCategorie();
    }

    public IActionResult OnPost()
    {
        // controllo se il model è valido cioè se i dati inseriti dall'utente rispettano le regole di validazione
        // se il modello non e valido ritorno la pagina con gli errori
        if (!ModelState.IsValid)
        {
            CaricaCategorie(); // carico le categorie se no quando si carica si carica senza categorie
            // page è un metodo di page model che restituisce un oggetto page result che rappresenta la pagina nella quale siamo
            return Page(); // se il modello non è valido ritorno la pagina
        }

        // invoco il metodo GetConnection per ottenere la connessione al db
        using var connection = DatabaseInitializer.GetConnection();
        // apro la connessione
        connection.Open();

        // Verifico se esiste già una categoria con lo stesso nome
        var checkSql = "SELECT COUNT(1) FROM Prodotti WHERE Nome = @nome"; // Conta quante righe nella tabella 'Prodotti' hanno un 'Nome' uguale al parametro @nome
        using var checkCommand = new SQLiteCommand(checkSql, connection);
        checkCommand.Parameters.AddWithValue("@nome", Prodotto.Nome);

        // dato che count di sql è un valore numerico, posso usare execute scalar per ottenere il valore
        // execute scalar ritorna un oggetto quindi faccio il casting a long per ottenere il valore numerico
        var count = (long)checkCommand.ExecuteScalar();

        if (count > 0)
        {
            // Aggiungo un errore di validazione se il prodotto esiste già
            // ModelState è un oggetto che contiene gli errori di validazione per il modello corrente (nel contesto di una pagina o di un form).
            // AddModelError è un metodo in ASP.NET (sia MVC che Razor Pages) che permette di aggiungere un errore di validazione al ModelState.
            ModelState.AddModelError("Prodotto.Nome", "Il prodotto con questo nome esiste già.");
            return Page();
        }

        // creo la query sql per inserire un nuovo prodotto usando i parametri
        // i parametri servono in modo da evitare sql injection
        // la sql injection è un attacco informatico che sfrutta le query sql per inserire codice
        // in pratica dobbiamo separare i dati dalla query sql e passarli come parametri dopo che sono stati validati
        // si mette davanti al valore del parametro la @ 
        var sql = "INSERT INTO Prodotti (Nome, Prezzo, CategoriaId) VALUES (@nome, @prezzo, @categoriaId)";

        // creo un comando sql per eseguire la query
        using var command = new SQLiteCommand(sql, connection);

        // aggiungo i parametri al comando con il metodo add with value che prende il nome del parametro e il valore
        command.Parameters.AddWithValue("@nome", Prodotto.Nome);
        command.Parameters.AddWithValue("@prezzo", Prodotto.Prezzo);
        command.Parameters.AddWithValue("@categoriaId", Prodotto.CategoriaId);

        // eseguo il comando
        command.ExecuteNonQuery();

        // reinderizzo l'utente alla pagina di elenco dei prodotti
        return RedirectToPage("Prodotti");
    }


    // metodo per caricare le categorie

    public void CaricaCategorie()
    {
        using var connection = DatabaseInitializer.GetConnection();
        connection.Open();

        // creo la query sql per ottenere i dati delle categorie
        var sql = "SELECT Id, Nome FROM Categorie";

        // creo un comando per eseguire la query
        using var command = new SQLiteCommand(sql, connection);
        // eseguo il comando e ottengo un reader che è un oggetto che mi permette di leggere i dati
        using var reader = command.ExecuteReader();

        // finche il reader ha dati
        while (reader.Read())
        {
            CategorieSelectList.Add(new SelectListItem
            {
                Value = reader.GetInt32(0).ToString(), // converto in stringa l'id cosi da poterlo usare come value
                Text = reader.GetString(1)
            });
        }
    }
}