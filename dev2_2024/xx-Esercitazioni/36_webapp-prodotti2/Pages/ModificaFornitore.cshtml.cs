using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
public class ModificaFornitoreModel : PageModel
{
    private readonly ILogger<ModificaFornitoreModel> _logger;

    public ModificaFornitoreModel(ILogger<ModificaFornitoreModel> logger)
    {
        _logger = logger;
    }

    public Fornitore Fornitore { get; set; }

    public void OnGet(int id)
    {
        var json = System.IO.File.ReadAllText("wwwroot/json/fornitori.json");
        var fornitori = JsonConvert.DeserializeObject<List<Fornitore>>(json);

        Fornitore = fornitori.FirstOrDefault(f => f.Id == id);
    }

    public IActionResult OnPost(int id, string nome, string indirizzo, string telefono, string email)
    {
        var json = System.IO.File.ReadAllText("wwwroot/json/fornitori.json");
        var fornitori = JsonConvert.DeserializeObject<List<Fornitore>>(json);

        var fornitore = fornitori.FirstOrDefault(f => f.Id == id);
        if (fornitore == null) return NotFound();

        fornitore.Nome = nome;
        fornitore.Indirizzo = indirizzo;
        fornitore.Telefono = telefono;
        fornitore.Email = email;

        System.IO.File.WriteAllText("wwwroot/json/fornitori.json", JsonConvert.SerializeObject(fornitori, Formatting.Indented));
        return RedirectToPage("Fornitori");
    }
}
