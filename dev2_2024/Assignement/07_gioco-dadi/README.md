# Gioco di dadi

## Versione 1 

## Obiettivo
- implementare un gioco di dadi umano contro computer.
- il giocatore ed il computer lanciano un dado a 6 facce.
- il punteggio più alto vince.
- il gioco deve chiedere all'utente se vuole continuare a giocare.
- il gioco in questa versione viene realizzato senza funzioni.

```csharp
Random random = new Random();
string risposta;

do
{
    // Lancia dado Giocatore
    int dadoGiocatore = random.Next(1, 7); // Genera un numero tra 1 e 6
    Console.WriteLine("Hai lanciato il dado! Il tuo punteggio è: " + dadoGiocatore);

    // Lancia dado Computer
    int dadoComputer = random.Next(1, 7); // Genera un numero tra 1 e 6
    Console.WriteLine("Il computer ha lanciato il dado! Il suo punteggio è: " + dadoComputer);

    // Determina il vincitore
    if (dadoGiocatore > dadoComputer)
    {
        Console.WriteLine("Hai vinto!");
    }
    else if (dadoGiocatore < dadoComputer)
    {
        Console.WriteLine("Ha vinto il computer.");
    }
    else
    {
        Console.WriteLine("È un pareggio!");
    }

    // Chiedi se l'utente vuole continuare
    Console.WriteLine("Vuoi continuare a giocare? (s/n): ");
    risposta = Console.ReadLine();
    
    while (risposta != "s" && risposta != "S" && risposta != "n" && risposta != "N")
    {
        Console.WriteLine("Risposta non valida. Vuoi giocare di nuovo? (s/n)");
        risposta = Console.ReadLine();

    }
}

while (risposta == "s" || risposta == "S") ;

Console.WriteLine("Grazie per aver giocato!");
```
## Versione 2

## Obiettivo
- implementare un gioco di dadi umano contro computer.
- il giocatore ed il computer lanciano un dado a 6 facce.
- il punteggio più alto vince.
- il gioco deve chiedere all'utente se vuole continuare a giocare.
- il gioco in questa versione viene realizzato con le funzioni.

```csharp
// Funzione per lanciare il dado
int LanciaDado()
{
    Random random = new Random();
    return random.Next(1, 7);  // Genera un numero casuale tra 1 e 6
}

// Funzione per determinare il vincitore
void DeterminaVincitore(int dadoGiocatore, int dadoComputer)
{
    if (dadoGiocatore > dadoComputer)
    {
        Console.WriteLine("Hai vinto!");
    }
    else if (dadoGiocatore < dadoComputer)
    {
        Console.WriteLine("Ha vinto il computer.");
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

    // Determina il vincitore
    DeterminaVincitore(dadoGiocatore, dadoComputer);

    // Chiedi se l'utente vuole continuare
    risposta = ChiediContinuare();

} 
while (risposta == "s" || risposta == "S");

Console.WriteLine("Grazie per aver giocato!");
```
# Versione 3

## Obiettivo
- implementare un sistema di punteggio.
- il giocatore ed il computer partono da un punteggio di 100 punti.
- al vincitore vengono assegnati 10 punti piu la differenza fra il lancio del dado del giocatore e del computer.
- al perdente vengo sottratti 10 punti piu la differenza fra il lancio del dado del giocatore e del computer
- ad esempio se il giocatore fa 6 ed il computer fa 3 il giocatore vince e guadagna 10 + 3 andando a 113 punti mentre il computer perde 10 + 3 andando a 87 punti.
- il gioco termina quando il giocatore o il computer raggiungono 0 punti.

