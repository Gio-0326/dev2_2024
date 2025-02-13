using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages; //pagine che contengono codice html e codice c#
using Microsoft.AspNetCore.Mvc.Rendering; //per utilizzare il SelectListItem ---> che mi serve per visualizzare il menu a tendina
using System.Data.SQLite;

public class EditModel : PageModel
{
    [BindProperty]
    public Prodotto Prodotto { get; set; }
    public List<SelectListItem> CategorieSelectList { get; set; } = new List<SelectListItem>();
    //passo l id come parametro perchè voglio modificare un prodottoesistente sul quale ho cliccato in precedenza
    public IActionResult OnGet(int id)
    {
        using var connection = DatabaseInitializer.GetConnection();
        connection.Open();
        //uso la clausola WHERE di sql in modo da ottenere solo il prodotto con id passato  come parametro
        var sql = "SELECT Id, Nome, Prezzo, CategoriaId FROM Prodotti WHERE Id = @id";
        using var command = new SQLiteCommand(sql, connection);
        command.Parameters.AddWithValue("@id", id);

        //eseguo il comando e ottengo il reeader che è un oggetto che permette di leggere i dati
        using var reader = command.ExecuteReader();

        //se il reader ha dati
        if (reader.Read())
        {
            Prodotto = new Prodotto
            {
                Id = reader.GetInt32(0),
                Nome = reader.GetString(1),
                Prezzo = reader.GetDouble(2),
                CategoriaId = reader.IsDBNull(3) ? 0 : reader.GetInt32(0)

            };
        }
        else
        {
            //se il prodotto non esiste ritorno NOT FOUND 
            // not found e un metodo di Page Model che restituisce un oggetto not found result che rappresenta la pagina  non trovata
            return NotFound();

        }
        //carico le categorie in modo da poterle visualizzare nella select list
        CaricaCategorie();
        //restituisce la pagina con i dati del prodotto da modificare
        return Page();

    }
    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            //se il modello non è valido carico  e restiituisco la pagina
            CaricaCategorie();
            return Page();

        }

        //invoco il metodo getconnection per ottenere la connessione al db ed apro la pagina
        using var connection = DatabaseInitializer.GetConnection();
        connection.Open();

        //costruisco la query basandomi sull input
        var sql = "UPDATE Prodotti SET Nome = @nome, Prezzo = @prezzo, CategoriaId = @categoriaId WHERE Id = @id";
        using var command = new SQLiteCommand(sql, connection);
        command.Parameters.AddWithValue("@nome", Prodotto.Nome);
        command.Parameters.AddWithValue("@prezzo", Prodotto.Prezzo);
        command.Parameters.AddWithValue("@categoriaId", Prodotto.CategoriaId);
        command.Parameters.AddWithValue("@id", Prodotto.Id);

        //eseguo il comando e aggiorno il prodotto poi reinderizzo alla pagina elenco dei prodotti
        command.ExecuteNonQuery();
        return RedirectToPage("Prodotti");
    }
    //metodo per caricare le categorie
    private void CaricaCategorie()
    {
        //Ottiene e apre una connessione al database.
        using var connection = DatabaseInitializer.GetConnection();
        connection.Open();

        //creo la query sql per ottenere i dati delle categorie
        var sql = "SELECT Id, Nome FROM Categorie";


        //creo un comando per eseguire la query
        using var command = new SQLiteCommand(sql, connection);
        //leggo il risultato 
        using var reader = command.ExecuteReader();

        //finche il reader ha dati
        while (reader.Read())
        {
            CategorieSelectList.Add(new SelectListItem
            {
                Value = reader.GetInt32(0).ToString(),// converto in string in modo da poter essere usato
                Text = reader.GetString(1)
            });
        }



    }
}