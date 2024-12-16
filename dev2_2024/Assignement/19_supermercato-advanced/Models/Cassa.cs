public class Cassa
{
    public int id { get; set;}
    public Dipendente dipendente { get; set; }
    public List<Purchases> acquisti { get; set; }
    public bool scontrinoProcessato { get; set; }
}