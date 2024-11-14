// Funzione per lanciare il dado
int LanciaDado()
{
    Random random = new Random();
    return random.Next(1, 7);  // Genera un numero casuale tra 1 e 6
}

// Funzione per determinare il vincitore
int punteggioInizialeComputer = 100;
int punteggioInizialeUtente = 100;
void DeterminaVincitore(int dadoGiocatore, int dadoComputer, int punteggioInizialeComputer, int punteggioInizialeUtente)
{
    if (dadoGiocatore > dadoComputer)
    {
        Console.WriteLine("Hai vinto!");
        punteggioInizialeUtente += 10 + (dadoGiocatore-dadoComputer);
        punteggioInizialeComputer -= 10 + (dadoGiocatore-dadoComputer);
    }
    else if (dadoGiocatore < dadoComputer)
    {
        Console.WriteLine("Ha vinto il computer.");
        punteggioInizialeComputer += 10 + (dadoComputer-dadoGiocatore);
        punteggioInizialeUtente -= 10 + (dadoComputer-dadoGiocatore);
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




string risposta;

do
{
    // Lancia il dado per il giocatore
    int dadoGiocatore = LanciaDado();
    Console.WriteLine("Hai lanciato il dado! Il tuo punteggio è: " + dadoGiocatore);

    // Lancia il dado per il computer
    int dadoComputer = LanciaDado();
    Console.WriteLine("Il computer ha lanciato il dado! Il suo punteggio è: " + dadoComputer);

// Calcolo la differenza di punteggio 
int differenza = dadoComputer - dadoGiocatore;

    // Determina il vincitore
    DeterminaVincitore(dadoGiocatore, dadoComputer, punteggioInizialeComputer, punteggioInizialeUtente);

    // Chiedi se l'utente vuole continuare
    risposta = ChiediContinuare();

} 
while (risposta == "s" || risposta == "S");

Console.WriteLine("Grazie per aver giocato!");


