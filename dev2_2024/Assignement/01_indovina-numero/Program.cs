﻿// possiamo evitare la confusione tra lettere maiuscole e minuscole (S s , N n) convertendo la risposta dell'utente in minuscolo o in maiuscolo cosi
// risposta = Console.ReadLine().ToLower(); // converto la risposta in minuscolo
// risposta = Console.ReadLine().ToUpper(); // converto la risposta in maiuscolo
Console.Clear();
Random random = new Random();
int numeroDaIndovinare = 0;
int punteggio = 0;
bool haIndovinato = false;
int tentativi = 0;
int numeroUtente = 0;

List<int> tentativiUtente = new List<int>(); // creo una lista per memorizzare i tentativi

string risposta = "s"; // inizializzo la risposta a "s" per far partire il gioco

do
{
    int scelta = 0;

    do
    {
        Console.WriteLine("Scegli il livello di difficolta':");
        Console.WriteLine("1. Facile (1-50, 10 tentativi)");
        Console.WriteLine("2. Medio (1-100, 7 tentativi)");
        Console.WriteLine("3. Difficile (1-200, 5 tentativi)");

        bool successoLivelloDifficolta = int.TryParse(Console.ReadLine(), out scelta);
        // pulisco la console
        Console.Clear();
        if (!successoLivelloDifficolta || scelta < 1 || scelta > 3)
        {
            Console.WriteLine("Scelta non valida.");
        }
    } while (scelta < 1 || scelta > 3);

    switch (scelta)
    {
        case 1:
            numeroDaIndovinare = random.Next(1, 51);
            punteggio = 100;
            tentativi = 10;
            break;
        case 2:
            numeroDaIndovinare = random.Next(1, 101);
            punteggio = 100;
            tentativi = 7;
            break;
        case 3:
            numeroDaIndovinare = random.Next(1, 201);
            punteggio = 100;
            tentativi = 5;
            break;
        default:
            Console.WriteLine("Scelta non valida.");
            break;
    }

    Console.WriteLine("Indovina il numero. Punteggio massimo: 100 punti.");

    while (!haIndovinato && tentativi > 0)
    {
        Console.Write("Tentativo: ");
        bool successo = int.TryParse(Console.ReadLine(), out numeroUtente);
        // pulisco la console
        Console.Clear();

        if (!successo)
        {
            Console.WriteLine("Inserisci un numero valido.");
            continue;
        }

        tentativiUtente.Add(numeroUtente);
        tentativi--;

        if (numeroUtente < numeroDaIndovinare)
        {
            Console.WriteLine("Il numero da indovinare e' maggiore.");
        }
        else if (numeroUtente > numeroDaIndovinare)
        {
            Console.WriteLine("Il numero da indovinare e' minore.");
        }
        else
        {
            Console.WriteLine($"Hai indovinato! Punteggio: {punteggio}");
            haIndovinato = true;
        }

        if (!haIndovinato && tentativi == 0)
        {
            Console.WriteLine($"Hai esaurito i tentativi. Il numero era {numeroDaIndovinare}.");
        }
    }

    Console.WriteLine("Tentativi effettuati: ");

    foreach (int tentativo in tentativiUtente)
    {
        Console.Write($"{tentativo} ");
    }

    Console.WriteLine("Vuoi giocare di nuovo? (s/n)");
    risposta = Console.ReadLine();
    // pulisco la console
        Console.Clear();
    while (risposta != "s" && risposta != "S" && risposta != "n" && risposta != "N")
    {
        Console.WriteLine("Risposta non valida. Vuoi giocare di nuovo? (s/n)");
        risposta = Console.ReadLine();
        // pulisco la console
        Console.Clear();
    }
    haIndovinato = false; // resetto la variabile haIndovinato
    tentativiUtente.Clear(); // cancello i tentativi effettuati

} while (risposta == "s" || risposta == "S");