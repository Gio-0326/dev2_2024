// La gestione dei file json è piu sicura se il path è privato
// dunque ogni file json avrà la propria Class Repository per salvare e caricare
using Newtonsoft.Json;
public class DipendenteRepository
{

    private readonly string folderPath = "Data/Dipendenti";

    public DipendenteRepository()  // ho fatto un costruttore per vedere se esiste la cartella. Se non esiste la crea
    {
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }
    }
    public void SalvaProdotti(Dipendente dipendente)
    {
        string filePath = Path.Combine(folderPath, $"{dipendente.id}.json"); // Ogni file è denominato con l'ID del prodotto
        string jsonData = JsonConvert.SerializeObject(dipendente, Formatting.Indented);
        File.WriteAllText(filePath, jsonData);
        Console.WriteLine($"Prodotto salvato in {filePath}");
    }

    // metodo per caricare i dati da file
    // restituisce una lista di prodotti se il file esiste e contiene dati
    public List<Dipendente> CaricaProdotti()
    {
        List<Dipendente> dipendenti = new List<Dipendente>(); // Crea una lista vuota che conterrà tutti i prodotti caricati

        if (Directory.Exists(folderPath)) // Verifica se la cartella esiste e contiene file
        {
            string[] filePaths = Directory.GetFiles(folderPath, "*.json"); // Ottiene tutti i percorsi dei file con estensione ".json" presenti nella cartella
            foreach (string filePath in filePaths) // Cicla su ogni file JSON trovato nella cartella
            {
                string jsonData = File.ReadAllText(filePath);  // Legge tutto il contenuto del file JSON
                Dipendente dipendente = JsonConvert.DeserializeObject<Dipendente>(jsonData);  // Mi deserializza il contenuto JSON in un oggetto 'ProdottoAdvanced'
                dipendenti.Add(dipendente); // Aggiunge l'oggetto 'ProdottoAdvanced' alla lista di prodotti
                Console.WriteLine($"Prodotto caricato da {filePath}: {dipendente.username}");
            }
        }
        else
        {
            Console.WriteLine("La cartella non esiste o è vuota. Inizializzare una nuova lista di prodotti.");
        }

        return dipendenti;   // Restituisce la lista di prodotti caricati (potrebbe essere vuota se la cartella non conteneva file)
    }
}