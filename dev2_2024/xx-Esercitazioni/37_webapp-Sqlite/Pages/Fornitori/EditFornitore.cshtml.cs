using Microsoft.AspNetCore.Mvc; // using in modo da usare IActionResult
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering; // using in modo da usare SelectListItem
using System.Data.SQLite;
using _37_webapp_Sqlite.Utilities;
namespace _37_webapp_Sqlite.Models;
public class EditFornitoreModel : PageModel
{
    [BindProperty]
    public Fornitore Fornitore { get; set; }

    public IActionResult OnGet(int id)
    {
        try
        {
            var Fornitori = DbUtils.ExecuteReader(
                "SELECT Id, Nome FROM Fornitori WHERE Id = @id",
                reader => new Fornitore
                {
                    Id = reader.GetInt32(0),
                    Nome = reader.GetString(1)
                },
                cmd =>
                {
                    cmd.Parameters.AddWithValue("@id", id);
                }
            );
            Fornitore = Fornitori.First();
        }
        catch (Exception ex)
        {
            SimpleLogger.Log(ex);
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

        try
        {
            DbUtils.ExecuteNonQuery(
                "UPDATE Fornitori SET Nome = @nome WHERE Id = @id",
                cmd =>
                {
                    cmd.Parameters.AddWithValue("@nome", Fornitore.Nome);
                    cmd.Parameters.AddWithValue("@id", Fornitore.Id);
                }
            );
        }
        catch (Exception ex)
        {
            SimpleLogger.Log(ex);
        }
        return RedirectToPage("Fornitori");
    }
}
