using _37_webapp_Sqlite.Utilities;
using Microsoft.AspNetCore.Mvc; // using in modo da usare IActionResult
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering; // using in modo da usare SelectListItem
using System.Data.SQLite;

namespace _37_webapp_Sqlite.Models;

public class DashboardModel : PageModel
{


    public List<ProdottoViewModel> ProdottiCostosi { get; set; } = new List<ProdottoViewModel>();
    public List<ProdottoViewModel> ProdottiCategoria { get; set; } = new List<ProdottoViewModel>();
    public List<ProdottoViewModel> ProdottiRecenti { get; set; } = new List<ProdottoViewModel>();

    public void OnGet()
    {
        try
        {
            ProdottiCostosi = DbUtils.ExecuteReader(
                "SELECT p.Id, p.Nome, p.Prezzo, c.Nome as CategoriaNome FROM Prodotti p LEFT JOIN Categorie c ON p.CategoriaId = c.Id ORDER BY p.Prezzo DESC LIMIT 5",
                reader => new ProdottoViewModel
                {
                    Id = reader.GetInt32(0),
                    Nome = reader.GetString(1),
                    Prezzo = reader.GetDouble(2),
                    CategoriaNome = reader.IsDBNull(3) ? "Nessuna" : reader.GetString(3)
                }
            );
        }
        catch (Exception ex)
        {
            SimpleLogger.Log(ex);
        }

        try
        {
            ProdottiRecenti = DbUtils.ExecuteReader(
                "SELECT p.Id, p.Nome, p.Prezzo, c.Nome as CategoriaNome FROM Prodotti p LEFT JOIN Categorie c ON p.CategoriaId = c.Id ORDER BY p.Id DESC LIMIT 5",
                reader => new ProdottoViewModel
                {
                    Id = reader.GetInt32(0),
                    Nome = reader.GetString(1),
                    Prezzo = reader.GetDouble(2),
                    CategoriaNome = reader.IsDBNull(3) ? "Nessuna" : reader.GetString(3)
                }
            );
        }
        catch (Exception ex)
        {
            SimpleLogger.Log(ex);
        }

        try
        {
            ProdottiCategoria = DbUtils.ExecuteReader(
                "SELECT p.Id, p.Nome, p.Prezzo, c.Nome as CategoriaNome FROM Prodotti p LEFT JOIN Categorie c ON p.CategoriaId = c.Id WHERE p.CategoriaId = 1  LIMIT 5",
                reader => new ProdottoViewModel
                {
                    Id = reader.GetInt32(0),
                    Nome = reader.GetString(1),
                    Prezzo = reader.GetDouble(2),
                    CategoriaNome = reader.IsDBNull(3) ? "Nessuna" : reader.GetString(3)
                }
            );
        }
        catch (Exception ex)
        {
            SimpleLogger.Log(ex);
        }
    }
}
/*using var connection = DatabaseInitializer.GetConnection();
connection.Open();

// query per selezionare i prodotti che contengono la stringa di ricerca
// il like è case insensitive di default in sqlite
// il like è una clausola che permette di fare una ricerca parziale

var sqlCostosi = @"
    SELECT p.Id, p.Nome, p.Prezzo, c.Nome as CategoriaNome
    FROM Prodotti p
    LEFT JOIN Categorie c ON p.CategoriaId = c.Id
    ORDER BY p.Prezzo DESC
    LIMIT 5";

// creo un comando sql per eseguire la query
using (var command = new SQLiteCommand(sqlCostosi, connection))

// ottengo il reader
using (var reader = command.ExecuteReader())
{
    // finche il reader ha qualcosa da leggere
    while (reader.Read())
    {
        // aggiungo un nuovo prodotto alla lista Prodotti
        ProdottiCostosi.Add(new ProdottoViewModel
        {
            Id = reader.GetInt32(0),
            Nome = reader.GetString(1),
            Prezzo = reader.GetDouble(2),
            CategoriaNome = reader.IsDBNull(3) ? "Nessuna" : reader.GetString(3)
        });
    }
}*/
/*var sqlRecenti = @"
    SELECT p.Id, p.Nome, p.Prezzo, c.Nome as CategoriaNome
    FROM Prodotti p
    LEFT JOIN Categorie c ON p.CategoriaId = c.Id
    ORDER BY p.Id DESC
    LIMIT 5";

// creo un comando sql per eseguire la query
using (var command = new SQLiteCommand(sqlRecenti, connection))

// ottengo il reader
using (var reader = command.ExecuteReader())
// finche il reader ha qualcosa da leggere
{
    while (reader.Read())
    {
        // aggiungo un nuovo prodotto alla lista Prodotti
        ProdottiRecenti.Add(new ProdottoViewModel
        {
            Id = reader.GetInt32(0),
            Nome = reader.GetString(1),
            Prezzo = reader.GetDouble(2),
            CategoriaNome = reader.IsDBNull(3) ? "Nessuna" : reader.GetString(3)
        });
    }
}*/

/*var sqlCategoria = @"
    SELECT p.Id, p.Nome, p.Prezzo, c.Nome as CategoriaNome
    FROM Prodotti p
    LEFT JOIN Categorie c ON p.CategoriaId = c.Id
    WHERE p.CategoriaId = 1  LIMIT 5";

// creo un comando sql per eseguire la query
using (var command = new SQLiteCommand(sqlCategoria, connection))

// ottengo il reader
using (var reader = command.ExecuteReader())
// finche il reader ha qualcosa da leggere
{
    while (reader.Read())
    {
        // aggiungo un nuovo prodotto alla lista Prodotti
        ProdottiCategoria.Add(new ProdottoViewModel
        {
            Id = reader.GetInt32(0),
            Nome = reader.GetString(1),
            Prezzo = reader.GetDouble(2),
            CategoriaNome = reader.IsDBNull(3) ? "Nessuna" : reader.GetString(3)
        });
    }
}*/

