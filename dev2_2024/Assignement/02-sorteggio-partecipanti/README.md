# Sorteggio partecipanti

## Versione 1

## Obiettivo

- Scrivere un programma che permette di sorteggiare i partecipanti del corso da una lista di nomi.
- I nomi vengono gestiti senza un inserimento da parte dell utente cioe vengono inizializzati nel programma.
- Il programma estrae un partecipante singolo alla volta e lo stampa a video.

```csharp
// Lista dei partecipanti predefiniti
        List<string> partecipanti = new List<string>
        {
            "Giorgio", "Andrea", "Anita", "Ivan", "Tamer", 
            "Diego", "Felipe", "Sofia"
        };

        // Oggetto per il generatore di numeri casuali
        Random random = new Random();

        // Continua finché ci sono partecipanti nella lista
        while (partecipanti.Count > 0)
        {
            // Estrai un indice casuale
            int indiceCasuale = random.Next(partecipanti.Count);

            // Prendi il partecipante con l'indice casuale
            string partecipanteEstratto = partecipanti[indiceCasuale];

            // Stampa il nome estratto
            Console.WriteLine($"Il partecipante estratto è: {partecipanteEstratto}");

            // Rimuovi il partecipante estratto dalla lista
            partecipanti.RemoveAt(indiceCasuale);
        }

        Console.WriteLine("Tutti i partecipanti sono stati estratti!");
```

## Versione 2

## Obiettivo

- Scrivere un programma che permetta di sorteggiare piu volte i partecipanti del corso da una lista di nomi.
- Il programma deve chiedere all utente se vuole estrarre un altro partecipante.
- I nomi dei partecipanti estratti vengono rimossi dalla lista.

```csharp
// Lista di partecipanti iniziale
        List<string> partecipanti = new List<string>
        {
            "Giorgio", "Tamer", "Anita", "Sofia", "Andrea", "Ivan", "Felipe" , "Diego"
        };

        Random random = new Random();

        // Continuare a estrarre finché ci sono partecipanti nella lista
        while (partecipanti.Count > 0)
        {
            // Chiedere all'utente se vuole estrarre un altro partecipante
            Console.WriteLine("Vuoi estrarre un altro partecipante? (s/n)");
            string risposta = Console.ReadLine().ToLower();

            // Se la risposta è 'n', il programma termina
            if (risposta == "n")
            {
                Console.WriteLine("Sorteggio terminato.");
                break;
            }

            // Se la risposta è 's', procediamo con l'estrazione
            if (risposta == "s")
            {
                // Estraiamo un nome casuale dalla lista
                int indice = random.Next(partecipanti.Count);
                string partecipanteEstratto = partecipanti[indice];

                // Visualizziamo il nome estratto
                Console.WriteLine($"Il partecipante estratto è: {partecipanteEstratto}");

                // Rimuoviamo il partecipante dalla lista
                partecipanti.RemoveAt(indice);

                // Visualizzare quanti partecipanti restano
                Console.WriteLine($"Partecipanti rimanenti: {partecipanti.Count}\n");
            }
            else
            {
                // Se la risposta non è valida
                Console.WriteLine("Risposta non valida. Inserisci 's' per estrarre o 'n' per terminare.");
            }
        }

        // Se la lista è vuota, informiamo l'utente
        if (partecipanti.Count == 0)
        {
            Console.WriteLine("Non ci sono più partecipanti nella lista.");
        }
```

## Versione 3

## Obiettivo

- Scrivere un programma che permetta di sorteggiare i partecipanti del corso da una lista di nomi dividendoli in gruppi.
- Il programma deve chiedere all utente il numero di squadre e il numero di partecipanti per squadra.
- Se il numero dei partecipanti non è divisibile per il numero di squadre, i partecipanti rimanenti vengono assegnati ad un gruppo in modo casuale.

```csharp

        // Richiesta di input
        Console.Write("Inserisci il numero di squadre: ");
        int numeroSquadre = int.Parse(Console.ReadLine());

        Console.Write("Inserisci il numero di partecipanti per squadra: ");
        int numeroPartecipantiPerSquadra = int.Parse(Console.ReadLine());

        // Calcola il numero totale di partecipanti
        Console.Write("Inserisci il numero totale di partecipanti: ");
        int numeroPartecipantiTotale = int.Parse(Console.ReadLine());

        // Controllo se i partecipanti totali sono sufficienti
        if (numeroPartecipantiTotale < numeroSquadre)
        {
            Console.WriteLine("Il numero di partecipanti deve essere maggiore o uguale al numero di squadre.");
            return;
        }

        // Creazione della lista dei partecipanti
        List<string> partecipanti = new List<string>();
        for (int i = 0; i < numeroPartecipantiTotale; i++)
        {
            Console.Write($"Inserisci il nome del partecipante #{i + 1}: ");
            partecipanti.Add(Console.ReadLine());
        }

        // Mescolamento casuale dei partecipanti
        Random rng = new Random();
        int n = partecipanti.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            string value = partecipanti[k];
            partecipanti[k] = partecipanti[n];
            partecipanti[n] = value;
        }

        // Creazione delle squadre
        List<List<string>> squadre = new List<List<string>>();
        int partecipantiPerSquadra = numeroPartecipantiTotale / numeroSquadre;
        int extra = numeroPartecipantiTotale % numeroSquadre;

        // Inizializzazione delle squadre vuote
        for (int i = 0; i < numeroSquadre; i++)
        {
            squadre.Add(new List<string>());
        }

        // Assegnamento partecipanti alle squadre
        int index = 0;
        for (int i = 0; i < numeroSquadre; i++)
        {
            int numeroPartecipantiDaAssegnare = partecipantiPerSquadra + (i < extra ? 1 : 0);

            for (int j = 0; j < numeroPartecipantiDaAssegnare; j++)
            {
                squadre[i].Add(partecipanti[index]);
                index++;
            }
        }

        // Visualizzazione dei gruppi
        Console.WriteLine("\nLe squadre sorte sono:");
        for (int i = 0; i < numeroSquadre; i++)
        {
            Console.WriteLine($"\nSquadra {i + 1}:");
            foreach (var partecipante in squadre[i])
            {
                Console.WriteLine(partecipante);
            }
        }
```