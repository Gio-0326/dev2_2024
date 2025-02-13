
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages; //pagine che contengono codice html e codice c#
using Microsoft.AspNetCore.Mvc.Rendering; //per utilizzare il SelectListItem ---> che mi serve per visualizzare il menu a tendina
using System.Data.SQLite;


public class DeleteModel : PageModel
{

    public ProdottoViewModel Prodotto { get; set; }
    public IActionResult OnGet(int id)
    {
        using var connection = DatabaseInitializer.GetConnection();
        connection.Open();

        var sql = @"
        SELECT p.Id, p.Nome, p.Prezzo, c.Nome as CategoriaNome
        FROM Prodotti p
        LEFT JOIN Categorie c ON p.CategoriaId = c.Id
        WHERE p.Id = @id";

        using var command = new SQLiteCommand(sql, connection);
        command.Parameters.AddWithValue("@id",id);

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

    }
        //uso l id del prodotto nell onpost
        public IActionResult OnPost(int id)
        {
            using var connection = DatabaseInitializer.GetConnection();
            connection.Open();

            var sql = "DELETE FROM Prodotti WHERE Id= @id";
            using var command = new SQLiteCommand(sql, connection);
            command.Parameters.AddWithValue("@id", id);
            command.ExecuteNonQuery();

            return RedirectToPage("Prodotti");
        }
        
}    