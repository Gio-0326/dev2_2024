# Sorteggio partecipanti con salvataggio su txt

## Obiettivo

- Creare un applicazione csharp che permetta di: 
- Sorteggiare i partecipanti da una lista di nomi presi da un file txt.
- I nomi sorteggiati devono essere salvati su un file txt di output.
- l programma chiede all utente quanti nomi sorteggiare
```csharp
    {
        // Chiedere all'utente il nome del file di input
        Console.WriteLine("Inserisci il nome del file di input (esempio: partecipanti.txt):");
        string inputFile = Console.ReadLine();

        // Verifica che il file esista
        if (!File.Exists(inputFile))
        {
            Console.WriteLine("Il file di input non esiste.");
            return;
        }

        // Leggere i nomi dal file
        List<string> partecipanti = LeggiPartecipanti(inputFile);
        
        // Chiedere all'utente quanti nomi sorteggiare
        Console.WriteLine("Quanti partecipanti vuoi sorteggiare?");
        int numSorteggi = int.Parse(Console.ReadLine());

        // Controllare se ci sono abbastanza partecipanti
        if (numSorteggi > partecipanti.Count)
        {
            Console.WriteLine("Numero di partecipanti da sorteggiare maggiore del numero di nomi disponibili.");
            return;
        }

        // Sorteggiare i partecipanti
        List<string> partecipantiSorteggiati = SorteggiaPartecipanti(partecipanti, numSorteggi);

        // Chiedere all'utente il nome del file di output
        Console.WriteLine("Inserisci il nome del file di output (esempio: sorteggi.txt):");
        string outputFile = Console.ReadLine();

        // Scrivere i partecipanti sorteggiati nel file di output
        ScriviSorteggioSuFile(partecipantiSorteggiati, outputFile);

        Console.WriteLine("Sorteggio completato. I risultati sono stati salvati in " + outputFile);
    }

    // Funzione per leggere i partecipanti dal file di input
    static List<string> LeggiPartecipanti(string filePath)
    {
        List<string> partecipanti = new List<string>();
        string[] lines = File.ReadAllLines(filePath);
        
        foreach (string line in lines)
        {
            if (!string.IsNullOrWhiteSpace(line))
                partecipanti.Add(line.Trim());
        }

        return partecipanti;
    }

    // Funzione per sorteggiare i partecipanti
    static List<string> SorteggiaPartecipanti(List<string> partecipanti, int numSorteggi)
    {
        Random rand = new Random();
        List<string> partecipantiSorteggiati = new List<string>();
        List<int> sorteggiatiIndice = new List<int>();

        while (partecipantiSorteggiati.Count < numSorteggi)
        {
            int indice = rand.Next(partecipanti.Count);
            if (!sorteggiatiIndice.Contains(indice))
            {
                partecipantiSorteggiati.Add(partecipanti[indice]);
                sorteggiatiIndice.Add(indice);
            }
        }

        return partecipantiSorteggiati;
    }

    // Funzione per scrivere i partecipanti sorteggiati in un file di output
    static void ScriviSorteggioSuFile(List<string> partecipantiSorteggiati, string filePath)
    {
        File.WriteAllLines(filePath, partecipantiSorteggiati);
    }
    ```