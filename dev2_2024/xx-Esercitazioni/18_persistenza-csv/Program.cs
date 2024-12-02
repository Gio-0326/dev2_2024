// GESTIONE FILES CSV

// ESEMPIO DI FILE CSV

// prodotto,quantità,prezzo
// Macchina,11,30
// Mouse,10,25

// LEGGERE UN CONTENUTO DA UN FILE CSV

/*string path = @"test.csv"; // in questo caso il file è nella stessa cartella del programma
string[] lines = File.ReadAllLines(path); // legge tutte le righe del file e le mette in un array di stringhe

foreach (string line in lines)
{
    Console.WriteLine(line); // stampa la riga
}

// creare una lista di stringhe partendo dal file CSV

List<string> list = new List<string>();

foreach (string line in lines)
{
    list.Add(line);
}

// creare un file CSV con il nome del file che corrisponde al nome della prima colonna 
// ed il contenuto del file che corrisponde al contenuto delle altre colonne disponibili

// Dati di esempio: ogni lista interna rappresenta una riga del CSV
        List<List<string>> righe = new List<List<string>>()
        {
            new List<string> { "prodotto", "quantità", "prezzo" },
            new List<string> { "Macchina", "11", "30" },
            new List<string> { "Mouse", "10", "25" }
        };

        // Percorso della cartella dove si vogliono salvare i file CSV
        string directoryPath = @"prodotto.csv";

        // Creazione dei file CSV
        foreach (var riga in righe)
        {
            // La prima colonna diventa il nome del file
            string fileName = riga[0] + ".csv";
            string filePath = Path.Combine(directoryPath, fileName);

            // Creiamo il contenuto del file CSV (saltiamo la prima colonna, che è già il nome del file)
            var fileContent = string.Join(",", riga.GetRange(1, riga.Count - 1));

            // Scriviamo il contenuto nel file
            File.WriteAllText(filePath, fileContent);

            Console.WriteLine($"File creato: {filePath}");
        }*/





// creare un file CSV inserire 

string filePath = @"test.csv";
File.Create(filePath).Close();

while (true)
{
    Console.WriteLine("Inserisci nome");
    string prodotto = Console.ReadLine();
    Console.WriteLine("Inserisci quantità");
    string quantita = Console.ReadLine();
    Console.WriteLine("Inserisci prezzo");
    string prezzo = Console.ReadLine();
    File.AppendAllText(filePath, $"\n{prodotto},{quantita},{prezzo}");
    Console.WriteLine("Vuoi inserire un altro prodotto? (s/n)");
    string risposta = Console.ReadLine();
    if (risposta == "n")
    {
        break;
    }
}

// eliminare un elemento specifico da un file csv

string prodottoDaEliminare = Console.ReadLine(); // Il valore della colonna che vogliamo rimuovere

// Leggere tutte le righe del file CSV
List<List<string>> csvData = new List<List<string>>();

foreach (var line in File.ReadLines(filePath))
{
    var columns = line.Split(','); // Separiamo i dati per virgola
    csvData.Add(new List<string>(columns));
}

// Rimuoviamo la riga che contiene il valore da eliminare nella prima colonna
csvData.RemoveAll(row => row[0] == prodottoDaEliminare);

// Riscrivere il contenuto del CSV senza la riga eliminata
using (var writer = new StreamWriter(filePath))
{
    foreach (var row in csvData)
    {
        writer.WriteLine(string.Join(",", row)); // Scriviamo ogni riga separata da virgola
    }
}

Console.WriteLine($"Elemento con valore '{prodottoDaEliminare}' eliminato.");

// modificare un elemento specifico da un file csv (prodotto, quantità, prezzo)

Console.WriteLine("Inserisci il nome del prodotto da modificare");
string prodottoDaModificare = Console.ReadLine();  // Il prodotto da modificare
string[] lines3 = File.ReadAllLines(filePath);
File.Create(filePath).Close();

foreach (string line in lines3)
{
    string[] data3 = line.Split(',');  // Separiamo la riga in colonne
    if (data3[0] == prodottoDaModificare)
    {
        Console.WriteLine("Inserisci la nuova quantità");
        string nuovaQuantità = Console.ReadLine();
        Console.WriteLine("Inserisci il nuovo prezzo");
        string nuovoPrezzo = Console.ReadLine();
    }
    else
    {
        File.AppendAllLines(filePath, line + "\n");
    }
}

