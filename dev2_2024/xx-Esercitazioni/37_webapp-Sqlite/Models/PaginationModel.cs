namespace _37_webapp_Sqlite.Models;
public class PaginationModel
{
    public int PageIndex { get; set; }
    public int TotalPages { get; set;}
    public bool HasPreviousPage => PageIndex > 1; 
    public bool HasNextPage => PageIndex < TotalPages; 
    // Funzione che, dato un numero di pagina, restituisce l'URL corrispondente.
    public Func<int, string> PageUrl { get; set; }
}
