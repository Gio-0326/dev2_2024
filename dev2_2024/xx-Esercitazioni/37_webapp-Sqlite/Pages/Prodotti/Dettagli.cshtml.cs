using _37_webapp_Sqlite.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Data.SQLite;
namespace _37_webapp_Sqlite.Models;
public class DettagliModel : PageModel
{
    public ProdottoViewModel Prodotto { get; set; }

    public IActionResult OnGet(int id)
    {
        try
        {
            var Prodotti = DbUtils.ExecuteReader(
                "SELECT p.Id, p.Nome, p.Prezzo, c.Nome as CategoriaNome FROM Prodotti p LEFT JOIN Categorie c ON p.CategoriaId = c.Id WHERE p.Id = @id",

                reader => new ProdottoViewModel
                {
                    Id = reader.GetInt32(0),
                    Nome = reader.GetString(1),
                    Prezzo = reader.GetDouble(2),
                    CategoriaNome = reader.IsDBNull(3) ? "Nessuna" : reader.GetString(3)
                },
                cmd =>
                {
                    cmd.Parameters.AddWithValue("@id", id);
                }
            );
            Prodotto = Prodotti.First();
        }
        catch (Exception ex)
        {
            SimpleLogger.Log(ex);
            return NotFound();
        }
        return Page();
    }
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
{
    Prodotto = new ProdottoViewModel
    {
        Id = reader.GetInt32(0),
        Nome = reader.GetString(1),
        Prezzo = reader.GetDouble(2),
        CategoriaNome = reader.IsDBNull(3) ? "Nessuna" : reader.GetString(3),
    };
}
else
{
    return NotFound(); // Se non trova il prodotto, ritorna NotFound
}

return Page();*/
