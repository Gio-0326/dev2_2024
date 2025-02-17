using _37_webapp_Sqlite.Utilities;
using Microsoft.AspNetCore.Mvc; // using in modo da usare IActionResult
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering; // using in modo da usare SelectListItem
using System.Data.SQLite;
namespace _37_webapp_Sqlite.Models;
public class CategorieModel : PageModel
{
    public List<Categoria> Categorie { get; set; } = new List<Categoria>();

    public void OnGet()
    {
        try
        {
            Categorie = DbUtils.ExecuteReader(
                "SELECT Id, Nome FROM Categorie",
                reader => new Categoria
                {
                    Id = reader.GetInt32(0),
                    Nome = reader.GetString(1)
                }
            );
        }
        catch (Exception ex)
        {
            SimpleLogger.Log(ex);
        }
    }
}
/* invoco il metodo GetConnection per ottenere la connessione al db
using var connection = DatabaseInitializer.GetConnection();
// apro la connessione
connection.Open();
// creo la query sql per ottenere i dati delle categorie
var sql = "SELECT Id, Nome FROM Categorie";
// creo un comando sql per eseguire la query
using var command = new SQLiteCommand(sql, connection);
// uso il reader come un cursore per scorrere i record restituiti dalla query
using var reader = command.ExecuteReader();

while (reader.Read())
{
    Categorie.Add(new Categoria
    {
        Id = reader.GetInt32(0),
        Nome = reader.GetString(1)
    });
}*/

