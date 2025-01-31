using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _34_webapp.Pages;

public class ProdottiModel : PageModel
{
    string parametro = "errore 404";
    private readonly ILogger<ProdottiModel> _logger; // Iniettiamo il logger

    public ProdottiModel(ILogger<ProdottiModel> logger)
    {
        _logger = logger;
        
        _logger.LogInformation("Messaggio di log con parametro {0}", parametro);
        /*_logger.LogTrace("Messaggio di log");
        _logger.LogDebug("Messaggio di log");
        _logger.LogWarning("Messaggio di log");
        _logger.LogError("Messaggio di log");
        _logger.LogCritical("Messaggio di log");*/
    }

    
    public void OnGet()
    {
        ViewData["Message"] = $"Messaggio di log con {parametro}";
    }
}

