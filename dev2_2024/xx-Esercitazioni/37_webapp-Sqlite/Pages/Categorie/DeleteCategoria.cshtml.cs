using Microsoft.AspNetCore.Mvc; // using in modo da usare IActionResult
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering; // using in modo da usare SelectListItem
using System.Data.SQLite;
using _37_webapp_Sqlite.Utilities;
namespace _37_webapp_Sqlite.Models;
public class DeleteCategoriaModel : PageModel
{
    public Categoria Categoria { get; set; }

    public IActionResult OnGet(int id)
    {
        try
        {
            var Categorie = DbUtils.ExecuteReader(
                "SELECT Id, Nome FROM Categorie WHERE Id = @id",
                reader => new Categoria
                {
                    Id = reader.GetInt32(0),
                    Nome = reader.GetString(1)
                },
                cmd =>
                {
                    cmd.Parameters.AddWithValue("@id", id);
                }
            );
            Categoria = Categorie.First();
        }
        catch (Exception ex)
        {
            SimpleLogger.Log(ex);
            return NotFound();
        }
        return Page();
    }
    /*using var connection = DatabaseInitializer.GetConnection();
    connection.Open();

    var sql = "SELECT Id, Nome FROM Categorie WHERE Id = @id";
    using var command = new SQLiteCommand(sql, connection);
    command.Parameters.AddWithValue("@id", id);

    using var reader = command.ExecuteReader();

    if (reader.Read())
    {
        Categoria = new Categoria
        {
            Id = reader.GetInt32(0),
            Nome = reader.GetString(1)
        };
    }
    else
    {
        return NotFound();
    }

    return Page();*/


    public IActionResult OnPost(int id)
    {
        try
        {
            DbUtils.ExecuteNonQuery(
                "DELETE FROM Categorie WHERE Id = @id",
                cmd =>
                {
                    cmd.Parameters.AddWithValue("@id", id);
                }
            );
        }
        catch (Exception ex)
        {
            SimpleLogger.Log(ex);
        }
        return RedirectToPage("Categorie");
    }
}
/*using var connection = DatabaseInitializer.GetConnection();
connection.Open();

var sql = "DELETE FROM Categorie WHERE Id = @id";
using var command = new SQLiteCommand(sql, connection);
command.Parameters.AddWithValue("@id", id);

command.ExecuteNonQuery();

return RedirectToPage("Categorie");*/

