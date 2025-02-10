using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
public class AggiungiFornitoreModel : PageModel
{
    [TempData]
    public string Messaggio { get; set; }

    public void OnGet() { } // OnGet vuoto, solo per visualizzare il modulo

    public IActionResult OnPost(string nome, string indirizzo, string telefono, string email)
    {
        var json = System.IO.File.ReadAllText("wwwroot/json/fornitori.json");
        var fornitori = JsonConvert.DeserializeObject<List<Fornitore>>(json);

        var id = 1; // Impostiamo l'ID iniziale come 1
        if (fornitori.Count > 0)
        {
            id = fornitori[fornitori.Count - 1].Id + 1;
        }

        fornitori.Add(new Fornitore
        {
            Id = id,
            Nome = nome,
            Indirizzo = indirizzo,
            Telefono = telefono,
            Email = email,
            Data = DateTime.Now
        });

        System.IO.File.WriteAllText("wwwroot/json/fornitori.json", JsonConvert.SerializeObject(fornitori, Formatting.Indented));

        Messaggio = "Fornitore aggiunto con successo!";
        TempData.Keep("Messaggio");
        return RedirectToPage("Fornitori"); // Redirige alla pagina Fornitori
    }
}
