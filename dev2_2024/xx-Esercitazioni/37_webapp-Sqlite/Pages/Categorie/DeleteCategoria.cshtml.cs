using Microsoft.AspNetCore.Mvc; // using in modo da usare IActionResult
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering; // using in modo da usare SelectListItem
using System.Data.SQLite;

public class DeleteCategoriaModel : PageModel
{
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

    public IActionResult OnPost(int id)
    {
        using var connection = DatabaseInitializer.GetConnection();
        connection.Open();

        var sql = "DELETE FROM Categorie WHERE Id = @id";
        using var command = new SQLiteCommand(sql, connection);
        command.Parameters.AddWithValue("@id", id);

        command.ExecuteNonQuery();

        return RedirectToPage("Categorie");
    }
}
