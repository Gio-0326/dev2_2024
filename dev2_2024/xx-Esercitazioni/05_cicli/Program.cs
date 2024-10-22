// CICLI
/*
I principali tipi di cicli sono:
- for
- while
- do while
- foreach
*/

// pulisce la console
Console.Clear();
// ESEMPIO DI FOR
// esegue un blocco di codice un numero di volte definito
for (int i = 0; i <= 10; i++) // i e una variabile di controllo che parte da 0 e finisce a 10
{
    Console.WriteLine(i); // stampa i che e il valore della variabile di controllo
}

// ESEMPIO DI WHILE
// esegue un blocco di codice finche una condizione e vera
int j = 0; // j e una variabile di controllo
while (j <= 10) // finche j e minore o uguale a 10
{
    Console.WriteLine(j); // stampa j
    j++; // incrementa j
}

// ESEMPIO DI DO WHILE CON TRUE
// esegue un blocco di codice almeno una volta e poi finche una condizione e vera
int k = 0; // k e una variabile di controllo
do
{
    Console.WriteLine(k); // stampa k
    k++; // incrementa k
} while (k <= 10); // finche k e minore o uguale a 10

while (true) // finche vero
{
    Console.WriteLine("inserisci un numero"); // stampa un messaggio
    string s = Console.ReadLine(); // legge una stringa da tastiera
    if (s == "exit") // se la stringa e uguale a "exit"
{
    break; // esce dal ciclo
}
}

// ESEMPIO DI DO WHILE
// esegue un blocco di codice almeno una volta e poi finche una condizione e vera

int l = 0; // 1 e una variabile di controllo
do
{
    Console.WriteLine(1); // stampa 1
    l++; // incrementa 1
} while (1 > 10); // finche 1 e maggiore di 10

// ALTRO ESEMPIO DI DO WHILE
int numero = 10; // numero e una variabile di controllo

do
{
    Console.WriteLine(numero); // stampa numero
    numero--; // decrementa numero
}
while (numero > 0); // finche numero e maggiore di 0
 
// ESEMPIO DI FOREACH
// esegue un blocco di codice per ogni elemento di una collezione come un array o una lista
// esempio che stampa il nome di ogni elemento di un array
string[] nomi = { "mario", "luigi", "peach" }; // array di stringhe
foreach (string nome in nomi) // per ogni stringa di nomi
// nome e una variabilie di controllo che contiene il valore dell elemento corrente
// nomi e l array di stringhe
{
    Console.WriteLine(nome); // stampa la stringa
}