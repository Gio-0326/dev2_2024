using Microsoft.AspNetCore.Mvc.RazorPages;
using _37_webapp_Sqlite.Utilities;

namespace _37_webapp_Sqlite.Models;

public class FornitoriModel : PageModel   //  La classe FornitoriModel è una pagina Razor che gestisce la logica per la visualizzazione della lista dei fornitori.
{
    public PaginatedList<Fornitore> Fornitori { get; set; }
    public int PageSize { get; set; } = 5; 

    public void OnGet(int? pageIndex)
    {
        try
        {
            // Se pageIndex è diverso da null, assegna il suo valore a currentPage; altrimenti, assegna 1.
            int currentPage = pageIndex ?? 1; 
            // Recupero il numero totale di prodotti
            int totalCount = DbUtils.ExecuteScalar<int>("SELECT COUNT(*) FROM Fornitori");
            // Calcola l'offset per la query
            int offset = (currentPage - 1) * PageSize;

            string sql = $@"SELECT f.Id, f.Nome
            FROM Fornitori f
            ORDER BY f.Id
            LIMIT {PageSize} OFFSET {offset}";

            // Utilizzo di DbUtils per leggere la lista dei fornitori
            List<Fornitore> items = DbUtils.ExecuteReader(sql,
                reader => new Fornitore
                {
                    Id = reader.GetInt32(0),
                    Nome = reader.GetString(1),
                }
            );
            // Crea l'oggetto paginato
        Fornitori = new PaginatedList<Fornitore>(items, totalCount, currentPage, PageSize);
        }
        catch (Exception ex)
        {
            SimpleLogger.Log(ex);
        }
    }
}
