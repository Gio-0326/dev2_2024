// GESTIONE FILES TXT

// LEGGERE UN CONTENUTO DA UN FILE TXT

string path = @"test.txt"; // in questo caso il file è nella stessa cartella del programma
string[] lines = File.ReadAllLines(path); // legge tutte le righe del file e le mette in un array di stringhe
foreach (string line in lines)
{
    Console.WriteLine(line); // stampa la riga
}

string[] nomi = new string[lines.Length]; // crea un array di stringhe con la lunghezza del numero di righe del file
for (int i = 0; i < lines.Length; i++)
{
    nomi[i] = lines[i]; // assegna ad ogni elemento dell'array di stringhe il valore della riga corrispondente
}
foreach (string nome in nomi)
{
    Console.WriteLine(nome); // stampa la riga
}
// LEGGERE UN CONTENUTO DA UN TXT E STAMPARE SOLO LE RIGHE CHE INIZIANO CON UNA DETERMINATA LETTERA

// string path = @"test.txt";
// string[] lines = File.ReadAllLines(path);

foreach (string line in lines)
{
    if (line.StartsWith("n")) // controlla se la riga inizia con la lettera
    {
        Console.WriteLine(line); // stampa la riga
    }
}

// LEGGERE UN CONTENUTO DA UN TXT E STAMPARE SOLO LE RIGHE CHE INIZIANO CON UNA DETERMINATA LETTERA
// SE NESSUN NOME INCOMINCIA CON LA LETTERA SCELTA DA UN MESSAGGIO DI ERRORE

bool nessunNome = true;

foreach (string line in lines)
{
    if (line.StartsWith("n")) // controlla se la riga inizia con la lettera
    {
        Console.WriteLine(line); // stampa la riga
        nessunNome = false;
    }
}

if (nessunNome)
{
    Console.WriteLine("Nessun nome inizia con la lettera scelta");
}

// LEGGERE UN CONTENUTO DA TXT E STAMPARE SOLO LE RIGHE CHE INIZIANO CON UNA DETERMINATA LETTERA
// SE NESSUN NOME INCOMINCIA CON LA LETTERA SCELTA DA UN MESSAGGIO DI ERRORE
// CREARE UN TXT CON LE RIGHE CHE INIZIANO CON LA LETTERA SCELTA

string path2 = @"testOutput.txt"; // in questo caso il file è nella stessa cartella del programma
File.Create(path2).Close(); // crea il file e lo chiude subito

foreach (string line in lines)
{
    if (line.StartsWith("a"))
    {
        // Console.WriteLine(line);
        nessunNome = false; // se trovo un nome che inizia con la lettera, il booleano divemta falso
        File.AppendAllText(path2, line + "\n"); // scrive la riga nel file di output andando a capo
    }
}
if (nessunNome) // se il booleano è vero allora stampa "nessun nome inizia con la lettera a"
{
    Console.WriteLine("nessun nome inizia con la lettera scelta");
}

// AGGIUNGERE UNA RIGA DI TESTO IN UNA POSIZIONE SPECIFICA

// stampo la lunghezza dell'array
Console.WriteLine(lines.Length);
lines[lines.Length - 2] += "INDIRIZZO"; // aggiunge "INDIRIZZO" alla penultima riga
File.WriteAllLines(path2, lines); // scrive tutte le righe nel file

// SOVRASCRIVERE UNA RIGA DI TESTO IN UNA POSIZIONE SPECIFICA

lines[lines.Length - 2] = "numero di telefono"; // aggiunge "INDIRIZZO" alla penultima riga
File.WriteAllLines(path2, lines); // scrive tutte le righe nel file

// AGGIUNGERE UNA RIGA DI TESTO IN UNA POSIZIONE SPECIFICA USANDO L ACCENTO CIRCONFLESSO

    lines[^ 2] += "numero di telefono 2"; // aggiunge il testo partendo dall ultima posizione
    File.WriteAllLines(path2, lines); // scrive tutte le righe nel file