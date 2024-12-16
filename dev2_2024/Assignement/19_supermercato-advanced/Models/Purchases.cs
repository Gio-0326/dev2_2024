public class Purchases
{
    public int id { get; set;}
    public Cliente cliente { get; set; }
    public List<Prodotto> prodotti { get; set; }
    public int giacenza { get; set; }
    public DateTime data { get; set; }
    public bool stato { get; set; }
}