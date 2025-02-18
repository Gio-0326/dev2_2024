public class PaginatedList<T> : List<T>
{
    public int PageIndex { get; private set; }
    public int TotalPages { get; private set; }
    public int PageSize { get; private set; }
    public int TotalCount { get; private set; }

    public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
    {
        TotalCount = count;
        PageSize = pageSize;
        PageIndex = pageIndex;
        TotalPages = (int)Math.Ceiling(count / (double)PageSize);
        this.AddRange(items); // Aggiunge gli elementi alla lista usando this che si riferisce alla lista stessa
    }
    public bool HasPreviousPage => PageIndex > 1; // Proprietà calcolata che restituisce true se c'è una pagina precedente
    public bool HasNextPage => PageIndex < TotalPages; // Proprietà calcolata che restituisce true se c'è una pagina successiva
}

