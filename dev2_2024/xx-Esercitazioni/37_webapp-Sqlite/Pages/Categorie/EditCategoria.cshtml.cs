using Microsoft.AspNetCore.Mvc; // using in modo da usare IActionResult
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering; // using in modo da usare SelectListItem
using System.Data.SQLite;
namespace _37_webapp_Sqlite.Models;
public class EditCategoriaModel : PageModel
{
    [BindProperty]
    public Categoria Categoria { get; set; }

    public IActionResult OnGet(int id)
    {
        using var connection = DatabaseInitializer.GetConnection();
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

        return Page();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        using var connection = DatabaseInitializer.GetConnection();
        connection.Open();

        var sql = "UPDATE Categorie SET Nome = @nome WHERE Id = @id";
        using var command = new SQLiteCommand(sql, connection);
        command.Parameters.AddWithValue("@nome", Categoria.Nome);
        command.Parameters.AddWithValue("@id", Categoria.Id);

        command.ExecuteNonQuery();

        return RedirectToPage("Categorie");
    }
}
