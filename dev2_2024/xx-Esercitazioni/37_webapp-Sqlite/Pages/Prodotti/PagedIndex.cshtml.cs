using _37_webapp_Sqlite.Models;
using _37_webapp_Sqlite.Utilities;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class PageIndexModel : PageModel
{
    public PaginatedList<ProdottoViewModel> Products { get; set; }
    public int PageSize { get; set; } = 5; // Numero di prodotti per pagina
    public void OnGet(int? pageIndex)
    {
        int currentPage = pageIndex ?? 1;
        // Reacupero il numero totale di prodotti
        int totalCount = DbUtils.ExecuteScalar<int>("SELECT COUNT(*) FROM Prodotti");
        // Calcola l'offset per la query
        int offset = (currentPage - 1) * PageSize;

        // Recupera i prodotti per la pagina corrente
        // in SQLite si usa LIMIT e OFFSET per la paginazione
        // limit = quanti elementi voglio
        // offset = da dove voglio partire
        // offset = (pagina corrente - 1) * elementi per pagina
        // LIMIT 5 OFFSET 0 -> 5 elementi a partire dall'elemento 0
        string sql = $@"
        SELECT p.Id, p.Nome, p.Prezzo, c.Nome as CategoriaNome
        FROM Prodotti p
        LEFT JOIN Categorie c ON p.CategoriaId = c.Id
        ORDER BY p.Id
        LIMIT {PageSize} OFFSET {offset}";

        List<ProdottoViewModel> items = DbUtils.ExecuteReader(sql,
        reader => new ProdottoViewModel
        {
            Id = reader.GetInt32(0),
            Nome = reader.GetString(1),
            Prezzo = reader.GetDouble(2),
            CategoriaNome = reader.IsDBNull(3) ? "Nessuna" : reader.GetString(3),
        }
        );

        // Crea l'oggetto paginato
        Products = new PaginatedList<ProdottoViewModel>(items, totalCount, currentPage, PageSize);
    }
}