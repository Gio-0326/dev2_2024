// I TIPI DI DATI SEMPLICI 

//variabili di tipo intero
int eta = 10; // dichiarazione e inizializzazione di una variabile di tipo intero

int eta2; // dichiarazione di una variabile di tipo intero
eta2 = 20; // inizializzazione di una variabile di tipo intero

// variabili di tipo decimale
double altezza = 1.70; // dichiarazione e inizializzazione di una variabile di tipo decimale

// varabiali di tipo carattere
char iniziale = 'M'; // dichiarazione e inizializzazione di una variabile di tipo carattere

// variabili di tipo stringa
string nome = "Mario"; // dichiarazione e inizializzazione di una variabile di tipo stringa

// variabili di tipo booleano
bool maggiorenne = true; // dichiarazione e inizializzazione di una variabile di tipo booleano

// variabili di tipo data
DateTime dataNascita = new DateTime(2000, 1, 1); // dichiarazione e inizializzazione di una variabile di tipo data

// esempio di utilizzo di una variabile attraverso i metodi di console
// utilizzando l interpolazione di stringhe
Console.WriteLine($"La variabile eta contiene il valore {eta}"); // output: La variabile eta contiene il valore 10
Console.WriteLine($"La variabile altezza contiene il valore {altezza}"); // output: La variabile altezza contiene il valore 1.70

// ricevo l input dall utente e lo salvo in una variabile
Console.WriteLine("Inserisci il tuo nome: ");
string nomeUtente = Console.ReadLine();
Console.WriteLine($"Ciao {nomeUtente}!"); // output: Ciao Mario!

// I TIPI DI DATI COMPLESSI (o strutture di dati)
// un insieme di dati dello stesso tipo 

// ARRAY
int[] numeri = new int[5]; // dichiarazione e inizializzazione di un array di interi di 5 elementi
                            // new e una parola chiave che serve per creare un nuovo oggetto (costruttore)
// inseimento di valori nell array
numeri[0] = 10; // inserisco il numero 10 nella prima posizione dell array
numeri[1] = 20;
numeri[2] = 30;
numeri[3] = 40;
numeri[4] = 50;

// inserimento di valori multipli nell array
int[] numeri2 = new int[] { 10, 20, 30, 40, 50 }; // dichiarazione e inizializzazione di un array di interi di 5 elementi

// la caratteristica principale degli array e che sono di dimensione fissa

// LISTA 
List<int> numeri3 = new List<int>(); // dichiarazione di una lista di interi
                                        // le liste sono di dimensione variabile

// inserimento di valori nella lista
numeri3.Add(10); // inserisco il valore nella lista usando il metodo Add
numeri3.Add(20);
numeri3.Add(30);
numeri3.Add(40);
numeri3.Add(50);

// inserimento di valori multipli nella lista
List<int> numeri4 = new List<int> { 10, 20, 30, 40, 50 }; // dichiarazione e inizializzazione di una lista di interi

// sia le liste che gli array sono collezioni di dati che possono essere di Int, Double; Char, String, ecc.
// esempio di lista di stringhe 
List<string> nomi = new List<string> { "Mario", "Luigi", "Peach"}; // dichiarazione e inizializzazione di una lista di stringhe

// DIZIONARIO
Dictionary<string, int> voti = new Dictionary<string, int>(); // dichiarazione di un dizionario con chiave di tipo stringa e un valore di tipo intero
// in questo caso string e la chiave ed int il valore

// BEST PRACTICES PER LA DICHIARAZIONE DI VARIABILI
// dichiarare le variabili con nomi significativi
// dichiarare le variabili con la notazione CamelCase o PascalCase
// esempio camel case etaStudente
// esempio pascal case EtaStudente
