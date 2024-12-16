public class Prodotto
{
    public int Id { get; set; } // Generato automaticamente
    public string Nome { get; set; } // Inserito dal magazziniere
    public decimal Prezzo { get; set; } // Inserito dal magazziniere
    public int Giacenza { get; set; } // Inserito dal magazziniere
    public string Categoria { get; set; } // Associato a una categoria esistente
}