
using _37_webapp_Sqlite.Utilities; // namespace per accedere alla cartella Utilities
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages; //pagine che contengono codice html e codice c#
using Microsoft.AspNetCore.Mvc.Rendering; //per utilizzare il SelectListItem ---> che mi serve per visualizzare il menu a tendina
using System.Data.SQLite;
namespace _37_webapp_Sqlite.Models;

public class DeleteModel : PageModel
{
    // Proprietà per memorizzare i dettagli del prodotto da visualizzare
    public ProdottoViewModel Prodotto { get; set; }
    public IActionResult OnGet(int id)
    {

        try
        {
            // Eseguiamo una query per recuperare i dettagli del prodotto con un certo id
            var Prodotti = DbUtils.ExecuteReader(
                 // La query SQL che recupera il prodotto con l'ID specificato
                "SELECT p.Id, p.Nome, p.Prezzo, c.Nome as CategoriaNome FROM Prodotti p LEFT JOIN Categorie c ON p.CategoriaId = c.Id WHERE p.Id = @id",
                 // LEFT JOIN per prendere i prodotti anche se non hanno una categoria associata
                 // Funzione di lettura per mappare i risultati della query in un oggetto ProdottoViewModel
                reader => new ProdottoViewModel
                {
                    Id = reader.GetInt32(0),
                    Nome = reader.GetString(1),
                    Prezzo = reader.GetDouble(2),
                    CategoriaNome = reader.IsDBNull(3) ? "Nessuna" : reader.GetString(3)  // Se la categoria è nulla (Nessuna categoria associata), la impostiamo a "Nessuna"
                },
                 // Comando per aggiungere il parametro 'id' alla query SQL
                cmd =>
                {
                    cmd.Parameters.AddWithValue("@id", id); // Aggiungiamo l'id del prodotto come parametro alla query
                }
            );
            // Assegniamo il primo risultato alla proprietà Prodotto
            Prodotto = Prodotti.First(); // primo e unico elemento dalla lista var prodotti attraverso .First()
        }
        catch (Exception ex)
        {
            // Se c'è un errore, lo registriamo nei log e ritorniamo un errore "Not Found"
            SimpleLogger.Log(ex);
            return NotFound();
        }
        return Page();
    }


    /*using var connection = DatabaseInitializer.GetConnection();
    connection.Open();

    var sql = @"
    SELECT p.Id, p.Nome, p.Prezzo, c.Nome as CategoriaNome
    FROM Prodotti p
    LEFT JOIN Categorie c ON p.CategoriaId = c.Id
    WHERE p.Id = @id";

    using var command = new SQLiteCommand(sql, connection);
    command.Parameters.AddWithValue("@id", id);

    using var reader = command.ExecuteReader();
    if (reader.Read())
        Prodotto = new ProdottoViewModel
        {

            Id = reader.GetInt32(0),
            Nome = reader.GetString(1),
            Prezzo = reader.GetDouble(2),
            CategoriaNome = reader.IsDBNull(3) ? "Nessuna" : reader.GetString(3)
        };
    else
    {
        return NotFound();
    }
    return Page();
    }*/


        //uso l id del prodotto nell onpost

     // Metodo che viene chiamato quando l'utente invia una richiesta "POST" (ad esempio per eliminare il prodotto)
    public IActionResult OnPost(int id)
    {
        try
        {
             // Eseguiamo una query per eliminare il prodotto dal database
            DbUtils.ExecuteNonQuery(
                 // La query SQL per eliminare il prodotto con l'ID specificato
                "DELETE FROM Prodotti WHERE Id= @id",
                 // Comando per aggiungere il parametro 'id' alla query SQL
                cmd =>
                {
                    cmd.Parameters.AddWithValue("@id", id); // Aggiungiamo l'id del prodotto come parametro alla query
                }
            );
        }
        catch (Exception ex)
        {
            SimpleLogger.Log(ex);  // Se c'è un errore, lo registriamo nei log
        }
        // Dopo aver eliminato il prodotto, reindirizziamo alla pagina che mostra tutti i prodotti rimanenti
        return RedirectToPage("Prodotti");
    }
}
// La sezione commentata qui sotto mostra un'alternativa per eseguire le stesse operazioni,
//ma utilizzando direttamente una connessione SQLite, senza l'ausilio di DbUtils.

/*using var connection = DatabaseInitializer.GetConnection();
connection.Open();

var sql = "DELETE FROM Prodotti WHERE Id= @id";
using var command = new SQLiteCommand(sql, connection);
command.Parameters.AddWithValue("@id", id);
command.ExecuteNonQuery();

return RedirectToPage("Prodotti");
}

}*/