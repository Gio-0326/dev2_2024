// FUNZIONI

// una funzione e un blocco di codice che esegue un compito specifico
// ci sono funzioni che elaborano i dati ma non restituiscono alcun valore
// ci sono funzioni che restituiscono un valore

// una funzione e composta da:
// - nome
// - parametri

// un esempio di funzione che non restituisce alcun valore (void)
// void NomeFunzione(parametri)
// {
//     codice
// }
// blocco di codice esterno alla funzione che la chiama

// esempio di funzione void che stampa un messaggio
void StampaMessaggio()
{
    Console.WriteLine("funzione void");
}
StampaMessaggio(); // utilizzo della funzione

// esempio di funzione void che stampa un messaggio con parametro
void StampaMessaggioConParametro(string messaggio)
{
    Console.WriteLine(messaggio);
}
StampaMessaggioConParametro("funzione void con parametro");// utilizzo della funzione

// esempio di funzione che stampa un messaggio con piu parametri
void StampaMessaggioConPiuParametri(string messaggio1, string messaggio2)
{
    Console.WriteLine($"{messaggio1} {messaggio2}");
}
StampaMessaggioConPiuParametri("funzione void con", "piu parametri");// utilizzo della funzione

// esempio di funzione che restituisce un valore
// una funzione che restituisce un valore deve specificare il tipo di quel valore al posto di void
// poiche prende due interi come parametri e restituisce la loro somma, il tipo di ritorno e int anziche void
int Somma(int a, int b)
{
    return a + b; // restituisce la somma di a e b
}
int risultato = Somma(2, 3); // utilizzo della funzione
Console.WriteLine(risultato); // stampa 5

// esempio di funzione che restituisce una stringa
string Saluta(string nome)
{
    return $"Ciao {nome}!"; // restituisce una stringa con il nome passato come parametro
}
string saluto = Saluta("studente"); // utilizzo della funzione
Console.WriteLine(saluto); // stampa Ciao studente

// esempio di funzione che restituisce un booleano
bool ParolaPari(string parola)
{
    return parola.Length % 2 == 0; // restituisce true se la lunghezza della parola e un intero pari, false altrimenti
}
bool risultatoPari = ParolaPari("cane"); // utilizzo della funzione
Console.WriteLine(risultatoPari); // stampa true

// esempio di funzione che restituisce piu valori
// una funzione puo restituire piu valori utilizzando i parametri out
void Divisione(int dividendo, int divisore, out int quoziente, out int resto)
{
    quoziente = dividendo / divisore; // calcola il quoziente
    resto = dividendo % divisore; // calcola il resto
    // non posso fare un return di due valori, quindi utilizzo i parametri out
}
int q, r;
Divisione(10, 3, out q, out r);
Console.WriteLine($"Quoziente: {q}, Resto: {r}"); // stampa Quoziente: 3, Resto: 1