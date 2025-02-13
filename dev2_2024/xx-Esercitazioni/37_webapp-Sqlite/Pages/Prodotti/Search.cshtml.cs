using Microsoft.AspNetCore.Mvc; // using in modo da usare IActionResult
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering; // using in modo da usare SelectListItem
using System.Data.SQLite;
// namespace Prodotti.Pages.Prodotti; se avessi il namespace

public class SearchModel : PageModel
{
    // proprietà pubblica che memorizzi la stringa di ricerca
    public string SearchTerm { get; set; }

    public List<ProdottoViewModel> Prodotti { get; set; } = new List<ProdottoViewModel>();

    public void OnGet(string q)
    {
        // assegno la stringa di ricerca alla proprietà pubblica SearchTerm
        SearchTerm = q;
        // se la stringa di ricerca non è vuota
        if (!string.IsNullOrWhiteSpace(q))
        {
            using var connection = DatabaseInitializer.GetConnection();
            connection.Open();  

            // query per selezionare i prodotti che contengono la stringa di ricerca
            // il like è case insensitive di default in sqlite
            // il like è una clausola che permette di fare una ricerca parziale

            var sql = @"
            SELECT p.Id, p.Nome, p.Prezzo, c.Nome as CategoriaNome
            FROM Prodotti p
            LEFT JOIN Categorie c ON p.CategoriaId = c.Id
            WHERE p.Nome LIKE @searchTerm";

            // creo un comando sql per eseguire la query
            using var command = new SQLiteCommand (sql, connection);
            // uso il parametro per evitare sql Injection con % + q + % in modo da cercare la stringa in qualsiasi parte del nome
            command.Parameters.AddWithValue("@searchTerm", $"%{q}%");
            // ottengo il reader
            using var reader = command.ExecuteReader();
            // finche il reader ha qualcosa da leggere
            while (reader.Read())
            {
                // aggiungo un nuovo prodotto alla lista Prodotti
                Prodotti.Add(new ProdottoViewModel
                { Id = reader.GetInt32(0),
                  Nome = reader.GetString(1),
                  Prezzo = reader.GetDouble(2),
                  CategoriaNome = reader.IsDBNull(3) ? "Nessuna" : reader.GetString(3)
                });
            }
        }
    }
}