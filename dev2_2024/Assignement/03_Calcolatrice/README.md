# Calcolatrice semplice

## Versione 1

## Obiettivo

- Scrivere un programma che simuli una calcolatrice semplice.
- L'utente deve poter inserire due numeri e selezionare un operatore matematico (+, -, *, /)
- Il programma deve eseguire l'operazione selezionata e stampare il risultato.
- Il programma non gestisce nessun tipo di errore o di eccezione.

```csharp
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

## Obittivo

- Aggiungere la gestione degli errori per evitare crash del programma.
- Se l'utente inserisce un valore non numerico, il programma deve stampare un messaggio di errore dicendo di inserire un numero valido
- Se l'utente tenta di dividere per zero, il programma deve stampare un messaggio di errore dicendo che la divisione per zero non è consentita
- Il programma deve usare i blocchi try-catch per gestire gli errori

```csharp

```