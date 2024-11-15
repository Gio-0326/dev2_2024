// Funzione per lanciare il dado
int LanciaDado()
{
    Random random = new Random();
    return random.Next(1, 7);  // Genera un numero casuale tra 1 e 6
}

// Funzione per determinare il vincitore
int punteggioInizialeComputer = 100;
int punteggioInizialeUtente = 100;
void DeterminaVincitore(int dadoGiocatore, int dadoComputer)
{
    if (dadoGiocatore > dadoComputer)
    {
        Console.WriteLine("Hai vinto!");
        punteggioInizialeUtente += 10 + (dadoGiocatore - dadoComputer);
        punteggioInizialeComputer -= 20 + (dadoGiocatore - dadoComputer);
    }
    else if (dadoGiocatore < dadoComputer)
    {
        Console.WriteLine("Ha vinto il computer.");
        punteggioInizialeComputer += 10 + (dadoComputer - dadoGiocatore);
        punteggioInizialeUtente -= 20 + (dadoComputer - dadoGiocatore);
    }
    else
    {
        Console.WriteLine("È un pareggio!");
    }
}

// Funzione per gestire la risposta dell'utente
string ChiediContinuare()
{
    Console.WriteLine("Vuoi continuare a giocare? (s/n): ");
    string risposta = Console.ReadLine();

    // Ciclo per gestire input non validi
    while (risposta != "s" && risposta != "S" && risposta != "n" && risposta != "N")
    {
        Console.WriteLine("Risposta non valida. Vuoi giocare di nuovo? (s/n): ");
        risposta = Console.ReadLine();
    }

    return risposta;
}
// Funzione per aggiungere un round allo storico
void AggiungiStorico(List<string> storicoPunteggi, int roundCount, int punteggioGiocatore, int punteggioComputer)
{
    storicoPunteggi.Add($"Round {roundCount}: Giocatore: {punteggioGiocatore}, Computer: {punteggioComputer}");
}

// Funzione per mostrare lo storico completo dei punteggi
void MostraStorico(List<string> storicoPunteggi)
{
    Console.WriteLine("\nStorico dei punteggi:");
    foreach (var entry in storicoPunteggi)
    {
        Console.WriteLine(entry);
    }
}

// Lista per lo storico dei punteggi
List<string> storicoPunteggi = new List<string>();
storicoPunteggi.Add($"Inizio gioco - Giocatore: {punteggioInizialeUtente}, Computer: {punteggioInizialeComputer}");

string risposta;

int roundCount = 1; // Inizializza il contatore dei round

do
{
    // Lancia il dado per il giocatore
    int dadoGiocatore = LanciaDado();
    Console.WriteLine("Hai lanciato il dado! Hai fatto: " + dadoGiocatore);

    // Lancia il dado per il computer
    int dadoComputer = LanciaDado();
    Console.WriteLine("Il computer ha lanciato il dado! Ha fatto: " + dadoComputer);

    // Determina il vincitore
    DeterminaVincitore(dadoGiocatore, dadoComputer);

    // Aggiungi l'aggiornamento del punteggio allo storico con il numero del round
    AggiungiStorico(storicoPunteggi, roundCount, punteggioInizialeUtente, punteggioInizialeComputer);

    // Visualizza i punteggi aggiornati
    Console.WriteLine($"Punteggio attuale - Giocatore: {punteggioInizialeUtente}, Computer: {punteggioInizialeComputer}");

    // Verifica se uno dei due ha raggiunto 0 punti
    if (punteggioInizialeUtente <= 0)
    {
        Console.WriteLine("Il gioco è finito! Il computer ha vinto.");
        break;
    }
    else if (punteggioInizialeComputer <= 0)
    {
        Console.WriteLine("Il gioco è finito! Hai vinto.");
        break;
    }

    // Incrementa il contatore dei round
    roundCount++;


    // Chiedi se l'utente vuole continuare
    risposta = ChiediContinuare();

}
while (risposta == "s" || risposta == "S");

// Mostra lo storico dei punteggi
MostraStorico(storicoPunteggi);

Console.WriteLine("Grazie per aver giocato!");


