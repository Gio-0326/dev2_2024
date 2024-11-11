# Calcolatrice semplice

## Versione 1

## Obiettivo

- Scrivere un programma che simuli una calcolatrice semplice.
- L'utente deve poter inserire due numeri e selezionare un operatore matematico (+, -, *, /)
- Il programma deve eseguire l'operazione selezionata e stampare il risultato.
- Il programma non gestisce nessun tipo di errore o di eccezione.

```csharp
 // Chiedi all'utente di inserire due numeri
Console.WriteLine("Inserisci due numeri");
double numeroUtente = int.Parse(Console.ReadLine());
double numeroUtente1 = int.Parse(Console.ReadLine());
// Chiedi all'utente di selezionare un operatore matematico
Console.Write("Scegli l'operatore (+, -, *, /): ");
string operatore = Console.ReadLine();
// Esegui l'operazione selezionata
 double risultato = 0;

        // Esegui l'operazione in base all'operatore scelto
        if (operatore == "+")
        {
            risultato = numero1 + numero2;
        }
        else if (operatore == "-")
        {
            risultato = numero1 - numero2;
        }
        else if (operatore == "*")
        {
            risultato = numero1 * numero2;
        }
        else if (operatore == "/")
        {
            if (numero2 != 0)
            {
                risultato = numero1 / numero2;
            }
            else
            {
                Console.WriteLine("Errore: Divisione per zero non permessa.");
                return;
            }
        }
        else
        {
            Console.WriteLine("Operatore non valido!");
            return;
        }

        // Stampa il risultato
        Console.WriteLine($"Il risultato di {numero1} {operatore} {numero2} è: {risultato}");
```
# Versione 2

## Obiettivo

- Aggiungere la gestione degli errori per evitare crash del programma.
- Se l'utente inserisce un valore non numerico, il programma deve stampare un messaggio di errore dicendo di inserire un numero valido
- Se l'utente tenta di dividere per zero, il programma deve stampare un messaggio di errore dicendo che la divisione per zero non è consentita
- Il programma deve usare i blocchi try-catch per gestire gli errori

```csharp

        double numeroUtente = 0;
        double numeroUtente1 = 0;
        string operatore = "";
        double risultato = 0;

        // Inserimento del primo numero con gestione degli errori
        Console.WriteLine("Inserisci il primo numero:");
        try
        {
            numeroUtente = double.Parse(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("Errore: Devi inserire un numero valido.");
            return; 
        }

        // Inserimento del secondo numero con gestione degli errori
        Console.WriteLine("Inserisci il secondo numero:");
        try
        {
            numeroUtente1 = double.Parse(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("Errore: Devi inserire un numero valido.");
            return; 
        }

        // Scelta dell'operatore
        Console.Write("Scegli l'operatore (+, -, *, /): ");
        operatore = Console.ReadLine();

        try
        {
            // Calcolo del risultato in base all'operatore scelto
            if (operatore == "+")
            {
                risultato = numeroUtente + numeroUtente1;
            }
            else if (operatore == "-")
            {
                risultato = numeroUtente - numeroUtente1;
            }
            else if (operatore == "*")
            {
                risultato = numeroUtente * numeroUtente1;
            }
            else if (operatore == "/")
            {
                if (numeroUtente1 == 0)
                {
                    Console.WriteLine("Errore: La divisione per zero non è consentita.");
                    return; 
                }
                risultato = numeroUtente / numeroUtente1;
            }
            else
            {
                Console.WriteLine("Errore: Operatore non valido.");
                return; 
            }

            // Visualizzazione del risultato
            Console.WriteLine($"Il risultato di {numeroUtente} {operatore} {numeroUtente1} è: {risultato}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Si è verificato un errore: {ex.Message}");
        }
```