public class Cliente
{
    public int id { get; set;}
    public string username { get; set; }
    public List<Prodotto> carrello { get; set; }
    public List<Purchases> storicoAcquisti { get; set; }
    public int percentualeSconto { get; set; }
    public double credito { get; set; }

} 

    