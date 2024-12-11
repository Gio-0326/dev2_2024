# Esercitazione 17: Supermercato completo

## Obiettivo:

- Implementare un programma che simuli il funzionamento di un supermercato.
- Il programma deve permettere ad un operatore di:
    - Gestire un catalogo di prodotti (Gestire prodotti del catalogo. Salvare e caricare il catalogo dei prodotti da un file JSON.)
- Il programma deve permettere a un cliente di riempire il proprio carrello della spesa
- Calcolare il totale del carrello e stampare uno scontrino

## Funzionalita':

Gestione del catalogo prodotti (operazioni CRUD):
- Id codice prodotto
- Nome prodotto
- Prezzo
- Quantità disponibile (in magazzino che viene decrementata quando un cliente acquista un prodotto)

Gestione del carrello e dello scontrino del cliente:
- Data di acquisto
- Lista dei prodotti acquistati
- Quantità per prodotto
- Totale spesa

Gestione dello store:
- Salvare il catalogo su file.
- Caricare il catalogo dal file.
- Salvare lo scontrino su file.
- Caricare lo scontrino dal file.
- Visualizzare il catalogo dei prodotti.
- Visualizzare gli scontrini.
- Implementare alcuni filtri (es. prodotti con prezzo minore di un certo valore, prodotti acquistati in una certa data, ecc.)

## Implementazioni future:

- Gestione operatori del supermercato (anagrafica, ruoli, ecc.)
- Gestione clienti (anagrafica, storico acquisti, ecc.)
- Gestione punti fedelta' (es. sconti, premi, ecc.)
- Gestione magazzino (funzionalita di rifornimento, gestione sottoscorta, ecc.)

## Versione 1
```csharp
using Newtonsoft.Json; // libreria per gestire il file JSON

string filePath = "catalogo.json"; // percorso del file JSON

// creo due liste di dizionari per il catalogo e il carrello
// i dizionari contengono le informazioni dei prodotti 
// i dizionari sono composti da coppie chiave-valore
// la chiave è una stringa, il valore è un oggetto generico
// il valore è un oggetto generico per poter contenere i valori di diversi tipi in questo caso stringhe, decimali, interi
var catalogo = new List<Dictionary<string, object>>(); // lista di dizionari per il catalogo
var carrello = new List<Dictionary<string, object>>(); // lista di dizionari per il carrello

Console.WriteLine("Benvenuto al supermercato JSON");

while (true)
{
    Console.WriteLine("\nScegli un'operazione:");
    Console.WriteLine("1. Aggiungi un prodotto al catalogo");
    Console.WriteLine("2. Salva il catalogo in JSON");
    Console.WriteLine("3. Carica il catalogo in JSON");
    Console.WriteLine("4. Mostra il catalogo");
    Console.WriteLine("5. Aggiungi prodotti al carrello");
    Console.WriteLine("6. Visualizza carrello e stampa scontrino");
    Console.WriteLine("7. Esci");

    string scelta = Console.ReadLine(); // legge l'input dell'utente

    switch (scelta)
    {
        case "1":
        var prodotto = CreaProdotto(); // crea un nuovo prodotto
        catalogo.Add(prodotto); // aggiunge il prodotto al catalogo, lo facciodirettamnete senza salvarlo in una variabileperchè non serve
        Console.WriteLine($"Prodotto {prodotto["Nome"]} aggiunto al catalogo"); // conferma l'aggiunta
        break;

        case "2":
        SalvaInJson(catalogo, filePath); //salva il catalogoin JSON
        Console.WriteLine("Catalogo salvato in Json");// conferma il salvataggio
        break;

        case "3":
        catalogo = CaricaDaJson(filePath); // carica il catalogo da JSON
        Console.WriteLine("Catalogo caricato da Json"); //conferma il caricamento
        break;

        case "4":
        MostraCatalogo(catalogo); // mostra il catalogo
        break;

        case "5":
        AggiungiAlCarrello(catalogo, carrello); //aggiunge prodotti al carrello
        break;

        case "6":
        VisualizzaCarrello(carrello); //visualizza il carrello e stampa lo scontrino
        break;

        case "7":
        Console.WriteLine("Grazie da Supermercato JSON"); // messaggio di uscita
        return;

        default:
        Console.WriteLine("Opzione non valida, riprova"); //messaggio di errore
        break;
    }
}

// la funzione CreaProdotto permette di creare un nuovo prodotto
//non accetta parametri
//restituisce un dizionario con le informazioni del prodotto
//la funzione è accessibile a tutto il programma in quanto statica
//la funzione statica permette di accedere alle variabili globali del programma senza doverle passare con parametri
static Dictionary<string, object> CreaProdotto()
{
    var prodotto = new Dictionary<string, object>(); //crea un nuovo dizionario per il prodotto che in questo caso
    // è un oggetto generico che ha come chiave una stringa (Nome, Prezzo, Quantità) e come valore un oggetto generico che può essere di diversi tipi (stringa, decimale, intero)

    Console.Write("Inserisci il nome del prodotto:");
    // devo mettere prodotto ["Nome"] perchè il dizionario è di tipo Dictionary<string, object> e non posso usare l'operatore.
    // per accedere ai campi quindi devo usare le parentesi quadre[] ed inserire la chiave
    prodotto["Nome"] = Console.ReadLine();

    Console.Write("Inserisci il prezzo del prodotto:");
    // converte la stringa in decimale e la mette nel dizionario come valore deciamle quindi devo usare [] per accedere al campo Prezzo
    prodotto["Prezzo"] = decimal.Parse(Console.ReadLine());

    Console.Write("Inserisci la quantità disponibile: ");
    prodotto["Quantità"] = int.Parse(Console.ReadLine());

    return prodotto; // restituisce il dizionario con le informazioni del prodotto
}

// la funzione salva in JSON permette di salvare una lista di dizionari in un file JSON
// accetta come parametri la lista di dizionari da salvare e il percorso del file JSON
// la funzione non restituisce nulla
static void SalvaInJson(List<Dictionary<string, object>> catalogo, string filePath)
{
    string json = JsonConvert.SerializeObject(catalogo, Formatting.Indented);
    File.WriteAllText(filePath, json);   
}

// la funzione carica da JSON permette di caricare una lista di dizionari da un file JSON
// accetta come parametro il percorso del file JSON
// restituisce la lista di dizionari caricata o una lista vuota se il file non esiste
static List<Dictionary<string, object>> CaricaDaJson(string filePath)
{
    if (!File.Exists(filePath)) // se il file non esiste
    {
        Console.WriteLine("Nessun file JSON trovato!");
        return new List<Dictionary<string, object>>(); // crea una lista vuota e la restituisce
    }

    string json = File.ReadAllText(filePath);
    return JsonConvert.DeserializeObject<List<Dictionary<string,object>>>(json);
}

// la funzione mostra catalogo permette di visualizzare il catalogo dei prodotti
// accetta come parametro la lista di dizionari del catalogo
// la funzione non restituisce nulla cioe non restituisce nessun valore da essere usato fuori dalla funzione
static void MostraCatalogo(List<Dictionary<string, object>> catalogo)
{
    if (catalogo.Count == 0) // se il catalogo è vuoto
    {
        Console.WriteLine("Il catalogo è vuoto.");
        return; // esce dalla funzione
    }

    Console.WriteLine("\n--- Catalogo Prodotti ---");
    foreach (var prodotto in catalogo)
    {
        Console.WriteLine($"{prodotto["Nome"]} - Prezzo: € {prodotto["Prezzo"]} - Quantità: {prodotto["Quantità"]}");
    }
}

// la funzione aggiungi al carrello permette di aggiungere prodotti al carrello 
// accetta come parametri la lista di dizionari del catalogo e la lista di dizionari del carrello
// la funzione non restituisce nulla
static void AggiungiAlCarrello(List<Dictionary<string, object>> catalogo, List<Dictionary<string, object>> carrello)
{
    if (catalogo.Count == 0)
    {
        Console.WriteLine("Il catalogo è vuoto, carica prima i prodotti!");
        return; // esco dalla funzione se il catalogo è vuoto
    }

    Console.Write("Inserisci il nome del prodotto da acquistare: ");
    string nome = Console.ReadLine();

    Dictionary<string, object> prodotto = null; // inizializzo il prodotto a null in modo da poter controllare se è stato trovato
    foreach (var p in catalogo)
    {
        if (p["Nome"].ToString().Equals(nome, StringComparison.OrdinalIgnoreCase))
        // uso [] per accedere al campo Nome del prodotto perchè il dizionario è di tipo Dictionary<string, object>
        // quindi non posso usare l'operatore . per accedere ai campi
        // StringComparison.OrdinalIgnoreCase serve per ignorare le maiuscole e minuscole
        // Equals restituisce true se le due stringhe sono uguali in quanto non possiamo usare l'operatore == per confrontare stringhe
        {
            prodotto = p; // assegno il prodotto trovato alla variabile prodotto in modo da poterlo usare fuori dal ciclo
            break; // esco dal ciclo dato che ho trovato il prodotto
        }
    }
    if (prodotto == null)
    {
        Console.WriteLine("Prodotto non trovato");
        return; // esco dalla funzione se il prodotto non è stato trovato
    }

    Console.Write("Inserisci la quantità da acquistare: ");
    int quantita = int.Parse(Console.ReadLine());

    if (quantita < int.Parse(prodotto["Quantità"].ToString())) // controllo se la quantità richiesta è disponibile nel catalogo
    {
        Console.WriteLine("Quantità non disponibile.");
        return; // esco dalla funzione se la quantità non è disponibile
    }

    prodotto["Qyantità"] = int.Parse(prodotto["Quantità"].ToString()) - quantita; // aggiorno la quantità disponibile nel catalogo

    carrello.Add(new Dictionary<string, object> // aggiungo il prodotto al carrello con la quantità scelta
    {
        {"Nome", prodotto["Nome"] },
        {"Prezzo", prodotto["Prezzo"] },
        {"Quantità", quantita } // aggiungo la quantita al carrello non metto ["Quantità"] perchè la quantità nel carrello è quella che l'utente ha scelto
    });

    Console.WriteLine($"{quantita} x {prodotto["Nome"]} aggiunti al carrello.");
}

// la funzione visualizza carrello permette di visualizzare il carrello e stampare lo scontrino
// accetta come parametro la lista di dizionari del carrello
// la funzione non restituisce nulla
static void VisualizzaCarrello(List<Dictionary<string, object>> carrello)
{
   if (carrello.Count == 0) 
   {
        Console.WriteLine("Il carrello è vuoto.");
        return;
   }

   Console.WriteLine("\n--- Carrello ---");

   decimal totale = 0; // inizializzo il totale a 0 per calcolare il costo totale del carrello se non lo inizializzo il valore di default è 0 quindi posso anche non scriverlo

   foreach (var prodotto in carrello)
   {
        decimal costo = decimal.Parse(prodotto["Prezzo"].ToString()) * int.Parse(prodotto["Quantità"].ToString()); // calcolo il costo del prodotto
        Console.WriteLine($"{prodotto["Quantità"]} x {prodotto["Nome"]} - €{costo}");
        totale += costo; // aggiorno il totale con il costo del prodotto acquistato
   }

   Console.WriteLine($"\nTotale: €{totale}");
}
```
# Versione 2
```csharp
using Newtonsoft.Json;

string fileCatalogo = @"catalogo.json"; // è il nome del file json
List<Dictionary<string, object>> carrello = new List<Dictionary<string, object>>(); // Lista del carrello
List<Dictionary<string, object>> catalogo = new List<Dictionary<string, object>>()
{
    new Dictionary<string, object> { { "Id", "001" }, { "Nome", "Pane" }, { "Prezzo", 1.50 }, { "Quantita", 100 } },
    new Dictionary<string, object> { { "Id", "002" }, { "Nome", "Latte" }, { "Prezzo", 0.99 }, { "Quantita", 50 } },
    new Dictionary<string, object> { { "Id", "003" }, { "Nome", "Mela" }, { "Prezzo", 2.00 }, { "Quantita", 200 } }
};
Dictionary<string, object> scontrino = new Dictionary<string, object>();

var catalogoJson = JsonConvert.SerializeObject(catalogo, Formatting.Indented);
File.WriteAllText(fileCatalogo, catalogoJson); // Scrivi il file JSON

Console.WriteLine("Benvenuto nel supermercato!");
string scelta;
do
{
    Console.WriteLine("Sei un cliente o un operatore?\n1. Cliente \n2. Operatore");
    Console.Write("Scegli un'opzione: ");
    scelta = Console.ReadLine()!;

    switch (scelta)
    {
        case "1":
            Cliente(carrello, fileCatalogo, catalogo, scontrino);
            break;

        case "2":
            Operatore(catalogo, fileCatalogo);
            break;

        default:
            Console.WriteLine("Non hai scelto l'opzione corretta!");
            break;
    }
} while (scelta != "1" && scelta != "2");

static void Cliente(List<Dictionary<string, object>> carrello, string fileCatalogo, List<Dictionary<string, object>> catalogo, Dictionary<string, object> scontrino)
{
    string scelta;
    do
    {
        Console.WriteLine("");
        Console.WriteLine("\n------- Menu Cliente -------");
        Console.WriteLine("1. Aggiungi al carrello");
        Console.WriteLine("2. Visualizza il carrello");
        Console.WriteLine("3. Modifica prodotto nel carrello");
        Console.WriteLine("4. Elimina prodotto dal carrello");
        Console.WriteLine("5. Stampa scontrino");
        Console.WriteLine("6. Esci");

        scelta = Console.ReadLine()!;

        switch (scelta)
        {
            case "1":
                Console.WriteLine("");
                AggiungiAlCarrello(carrello, catalogo, fileCatalogo);
                break;

            case "2":
                Console.WriteLine("");
                VisualizzaCarrello(carrello);
                break;

            case "3":
                Console.WriteLine("");
                ModificaCarrello(carrello, catalogo, fileCatalogo);
                break;

            case "4":
                Console.WriteLine("");
                EliminaDalCarrello(carrello, catalogo, fileCatalogo);
                break;

            case "5":
                Console.WriteLine("");
                VisualizzaeStampaScontrino(carrello, scontrino);
                break;

            case "6":
                Console.WriteLine("Arrivederci!");
                return;

            default:
                Console.WriteLine("Non hai scelto l'opzione corretta!");
                break;
        }
    }
    while (scelta != "6");
}

static void Operatore(List<Dictionary<string, object>> catalogo, string fileCatalogo)
{
    string scelta;
    do
    {
        Console.WriteLine("");
        Console.WriteLine("------- Menu Operatore -------");
        Console.WriteLine("1. Aggiungi al catalogo");
        Console.WriteLine("2. Visualizza il catalogo");
        Console.WriteLine("3. Modifica prodotto nel catalogo");
        Console.WriteLine("4. Elimina prodotto dal catalogo");
        Console.WriteLine("5. Esci");

        scelta = Console.ReadLine()!;

        switch (scelta)
        {
            case "1":
                Console.WriteLine("");
                AggiungiAlCatalogo(catalogo, fileCatalogo);
                break;

            case "2":
                Console.WriteLine("");
                VisualizzaCatalogo(catalogo);
                break;

            case "3":
                Console.WriteLine("");
                ModificaCatalogo(catalogo, fileCatalogo);
                break;

            case "4":
                Console.WriteLine("");
                EliminaDalCatalogo(catalogo, fileCatalogo);
                break;

            case "5":
                Console.WriteLine("Arrivederci!");
                return;
            default:
                Console.WriteLine("Non hai scelto l'opzione corretta!");
                break;
        }
    }
    while (scelta != "6");
}

static void AggiungiAlCatalogo(List<Dictionary<string, object>> catalogo, string fileCatalogo)
{
    VisualizzaCatalogo(catalogo);

    Console.WriteLine("");
    Console.Write("Inserisci ID prodotto: ");
    string id = Console.ReadLine()!;

    Console.Write("Inserisci nome prodotto: ");
    string nome = Console.ReadLine()!;

    Console.Write("Inserisci prezzo prodotto: ");
    string prezzo = Console.ReadLine()!;

    Console.Write("Inserisci quantità disponibile: ");
    string quantita = Console.ReadLine()!;

    catalogo.Add(new Dictionary<string, object>
    {
        { "Id", id },
        { "Nome", nome },
        { "Prezzo", Convert.ToDouble(prezzo) },
        { "Quantita", Convert.ToInt32(quantita) }
    });

    // Serializzazione della lista catalogo aggiornata in formato JSON.
    var catalogoJson = JsonConvert.SerializeObject(catalogo, Formatting.Indented);

    // Scrittura del JSON nel file, sovrascrivendo il vecchio file.
    File.WriteAllText(fileCatalogo, catalogoJson);

    Console.WriteLine($"Prodotto aggiunto al catalogo.");
}

static List<Dictionary<string, object>> VisualizzaCatalogo(List<Dictionary<string, object>> catalogo)
{
    Console.WriteLine("------- Catalogo -------");
    foreach (var prodotto in catalogo)
    {
        Console.WriteLine($"Id: {prodotto["Id"]} - Nome: {prodotto["Nome"]} - Prezzo: {prodotto["Prezzo"]:C2} - Quantita: {prodotto["Quantita"]}");
    }

    return catalogo;
}

static void ModificaCatalogo(List<Dictionary<string, object>> catalogo, string fileCatalogo)
{
    VisualizzaCatalogo(catalogo);

    Console.WriteLine("");
    Console.Write("Inserisci il nome del prodotto da modificare: ");
    string nome = Console.ReadLine()!;

    var prodottoDaModificare = catalogo.FirstOrDefault(p => p.ContainsKey("Nome") && p["Nome"].ToString() == nome);

    if (prodottoDaModificare != null)
    {
        Console.WriteLine($"Prodotto trovato: {prodottoDaModificare["Nome"]}, Prezzo: {prodottoDaModificare["Prezzo"]}, Quantità: {prodottoDaModificare["Quantita"]}");

        Console.Write("Vuoi modificare il nome del prodotto? (premi Enter per mantenere il nome attuale): ");
        string nuovoNome = Console.ReadLine()!;
        if (!string.IsNullOrEmpty(nuovoNome))
        {
            prodottoDaModificare["Nome"] = nuovoNome;
        }

        Console.Write("Vuoi modificare il prezzo del prodotto? (premi Enter per mantenere il prezzo attuale): ");
        string nuovoPrezzo = Console.ReadLine()!;
        if (!string.IsNullOrEmpty(nuovoPrezzo) && double.TryParse(nuovoPrezzo, out double prezzo)) 
        {
            prodottoDaModificare["Prezzo"] = prezzo;
        }

        Console.Write("Vuoi modificare la quantità disponibile? (premi Enter per mantenere la quantità attuale): ");
        string nuovaQuantita = Console.ReadLine()!;
        if (!string.IsNullOrEmpty(nuovaQuantita) && int.TryParse(nuovaQuantita, out int quantita))
        {
            prodottoDaModificare["Quantita"] = quantita;
        }

        var catalogoJson = JsonConvert.SerializeObject(catalogo, Formatting.Indented);
        File.WriteAllText(fileCatalogo, catalogoJson);

        Console.WriteLine("Prodotto aggiornato.");
    }
    else
    {
        Console.WriteLine($"Prodotto con nome '{nome}' non trovato.");
    }
}

static void EliminaDalCatalogo(List<Dictionary<string, object>> catalogo, string fileCatalogo)
{
    VisualizzaCatalogo(catalogo);

    Console.WriteLine("");
    Console.Write("Inserisci il nome del prodotto da eliminare: ");
    string nomeProdotto = Console.ReadLine()!;

    var prodottoDaEliminare = catalogo.FirstOrDefault(p => p.ContainsKey("Nome") && p["Nome"].ToString() == nomeProdotto);

    if (prodottoDaEliminare != null)
    {
        catalogo.Remove(prodottoDaEliminare);

        var catalogoJson = JsonConvert.SerializeObject(catalogo, Formatting.Indented);
        File.WriteAllText(fileCatalogo, catalogoJson);

        Console.WriteLine($"Prodotto rimosso.");
    }
    else
    {
        Console.WriteLine($"Prodotto non trovato.");
    }
}

static void VisualizzaeStampaScontrino(List<Dictionary<string, object>> carrello, Dictionary<string, object> scontrino)
{
    if (carrello.Count == 0)
    {
        Console.WriteLine("Il carrello è vuoto.");
        return;
    }

    // Calcola il totale del carrello (somma dei prezzi di tutti i prodotti)
    double totaleCarrello = 0;

    // Lista dei prodotti acquistati con la quantità e il totale per prodotto
    List<string> prodottiAcquistati = new List<string>();

    foreach (var prodotto in carrello)
    {
        double prezzoSingolo = Convert.ToDouble(prodotto["Prezzo singolo"]);
        int quantita = Convert.ToInt32(prodotto["Quantita"]);
        double totaleProdotto = prezzoSingolo * quantita;

        // Aggiungi il prodotto alla lista degli acquisti
        prodottiAcquistati.Add($"{prodotto["Nome"]} x{quantita} - Prezzo: {prezzoSingolo:C2} - Totale: {totaleProdotto:C2}");

        // Aggiungi il totale del prodotto al totale carrello
        totaleCarrello += totaleProdotto;
    }

    // Aggiungi i dettagli allo scontrino
    scontrino = new Dictionary<string, object> 
    { 
        { "DataAcquisto", DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") }, 
        { "ProdottiAcquistati", prodottiAcquistati }, 
        { "TotaleSpesa", totaleCarrello.ToString("F2") } 
    }; 

    // Visualizza lo scontrino nel terminale
    Console.WriteLine("\n-------- Scontrino --------");
    Console.WriteLine($"Data: {scontrino["DataAcquisto"]}"); 
    Console.WriteLine("Prodotti Acquistati:");
    foreach (var prodotto in scontrino["ProdottiAcquistati"] as List<string>)
    {
        Console.WriteLine(prodotto);
    }
    Console.WriteLine($"Totale Scontrino: {scontrino["TotaleSpesa"]:C2}"); 

    // Salva lo scontrino in un file JSON
    var fileScontrino = @"scontrino.json";
    var scontrinoJson = JsonConvert.SerializeObject(scontrino, Formatting.Indented);
    File.WriteAllText(fileScontrino, scontrinoJson); // Scrivi il file JSON
    Console.WriteLine("\nScontrino salvato in 'scontrino.json'.");
}


static void AggiungiAlCarrello(List<Dictionary<string, object>> carrello, List<Dictionary<string, object>> catalogo, string fileCatalogo)
{
    VisualizzaCatalogo(catalogo);

    Console.WriteLine("");
    Console.Write("Inserisci il nome del prodotto: ");
    string nome = Console.ReadLine()!;

    Console.Write("Inserisci la quantità: ");
    string quantita = Console.ReadLine()!;

    var prodotto = catalogo.FirstOrDefault(p => p["Nome"].ToString() == nome);

    if (prodotto == null)
    {
        Console.WriteLine("Prodotto non trovato.");
        return;
    }

    if (int.Parse(prodotto["Quantita"].ToString()!) < int.Parse(quantita))
    {
        Console.WriteLine("Quantità non disponibile.");
        return;
    }

    carrello.Add(new Dictionary<string, object>
    {
        { "Nome", prodotto["Nome"] },
        { "Prezzo singolo", prodotto["Prezzo"] },
        { "Quantita", quantita },
        { "Prezzo", (Convert.ToDouble(prodotto["Prezzo"]) * int.Parse(quantita)).ToString("F2") },
        
    });

    prodotto["Quantita"] = (int.Parse(prodotto["Quantita"].ToString()!) - int.Parse(quantita)).ToString();
    // Sovrascrivi il file JSON con il catalogo aggiornato
    var catalogoJson = JsonConvert.SerializeObject(catalogo, Formatting.Indented);
    File.WriteAllText(fileCatalogo, catalogoJson);

    Console.WriteLine("Prodotto aggiunto al carrello.");
    VisualizzaCarrello(carrello);
}

static void VisualizzaCarrello(List<Dictionary<string, object>> carrello)
{
    if (carrello.Count == 0)
    {
        Console.WriteLine("Il carrello è vuoto.");

    }
    else
    {
        Console.WriteLine("");
        Console.WriteLine("------- Carrello -------");
        foreach (var prodotto in carrello)
        {
            Console.WriteLine($"Nome: {prodotto["Nome"]} - Prezzo: {prodotto["Prezzo"]:C2} - Quantita: {prodotto["Quantita"]}");
        }
    }
}

static void ModificaCarrello(List<Dictionary<string, object>> carrello, List<Dictionary<string, object>> catalogo, string fileCatalogo)
{
    if (carrello.Any()) // Verifica che ci siano articoli nel carrello
    {
        VisualizzaCarrello(carrello);

        Console.WriteLine("");
        Console.Write("Inserisci il nome dell'articolo che desideri modificare: ");
        string nome = Console.ReadLine()!;

        // Trova il prodotto nel carrello
        var prodottoDaModificare = carrello.FirstOrDefault(p => p.ContainsKey("Nome") && p["Nome"].ToString() == nome);

        if (prodottoDaModificare != null)
        {
            Console.WriteLine($"Prodotto trovato: {prodottoDaModificare["Nome"]}, Prezzo: {prodottoDaModificare["Prezzo"]}, Quantità: {prodottoDaModificare["Quantita"]}");

            // Chiedi la nuova quantità
            Console.Write("Inserisci la nuova quantità: ");
            if (int.TryParse(Console.ReadLine(), out int nuovaQuantita) && nuovaQuantita > 0)
            {
                // Calcola la differenza di quantità
                int vecchiaQuantita = Convert.ToInt32(prodottoDaModificare["Quantita"]);
                int differenzaQuantita = nuovaQuantita - vecchiaQuantita;

                // Aggiorna la quantità nel carrello
                prodottoDaModificare["Quantita"] = nuovaQuantita;

                // Ricalcola il totale
                double prezzo = Convert.ToDouble(prodottoDaModificare["Prezzo"]);
                prodottoDaModificare["Totale"] = prezzo * nuovaQuantita;

                Console.WriteLine($"Quantità aggiornata a {nuovaQuantita}. Totale aggiornato a {Convert.ToDouble(prodottoDaModificare["Totale"]):C2}.");

                // Trova il prodotto nel catalogo per aggiornare la quantità disponibile
                var prodottoNelCatalogo = catalogo.FirstOrDefault(p => p.ContainsKey("Nome") && p["Nome"].ToString() == nome);
                if (prodottoNelCatalogo != null)
                {
                    int quantitaCatalogo = Convert.ToInt32(prodottoNelCatalogo["Quantita"]);

                    // Se la quantità nel carrello è stata ridotta, aggiungi la differenza al catalogo
                    if (differenzaQuantita < 0)
                    {
                        prodottoNelCatalogo["Quantita"] = quantitaCatalogo - differenzaQuantita;
                    }
                    // Se la quantità nel carrello è stata aumentata, sottrai la differenza dal catalogo
                    else if (differenzaQuantita > 0)
                    {
                        // Verifica che ci sia abbastanza disponibilità nel catalogo
                        if (quantitaCatalogo >= differenzaQuantita)
                        {
                            prodottoNelCatalogo["Quantita"] = quantitaCatalogo - differenzaQuantita;
                        }
                        else
                        {
                            Console.WriteLine($"Errore: la quantità nel catalogo non è sufficiente. Disponibilità nel catalogo: {quantitaCatalogo}");
                            return;
                        }
                    }

                    Console.WriteLine($"La quantità del prodotto nel catalogo è stata aggiornata a {prodottoNelCatalogo["Quantita"]}.");
                }
                else
                {
                    Console.WriteLine("Errore: prodotto non trovato nel catalogo.");
                }

                // Scrivere le modifiche nel file JSON
                var catalogoJson = JsonConvert.SerializeObject(catalogo, Formatting.Indented);
                File.WriteAllText(fileCatalogo, catalogoJson); // Sovrascrivi il file JSON con il catalogo aggiornato
            }
            else
            {
                Console.WriteLine("Quantità non valida.");
            }
        }
        else
        {
            Console.WriteLine("Prodotto non trovato nel carrello.");
        }
    }
    else
    {
        Console.WriteLine("Il carrello è vuoto.");
    }
}

static void EliminaDalCarrello(List<Dictionary<string, object>> carrello, List<Dictionary<string, object>> catalogo, string fileCatalogo)
{
    VisualizzaCarrello(carrello);

    Console.Write("Inserisci il nome del prodotto da eliminare: ");
    string nome = Console.ReadLine()!;

    // Trova il prodotto da eliminare nel carrello
    var prodottoDaEliminare = carrello.FirstOrDefault(p => p.ContainsKey("Nome") && p["Nome"].ToString() == nome);

    if (prodottoDaEliminare != null)
    {
        // Recupera la quantità del prodotto da rimuovere dal carrello
        int quantitaDaRimuovere = Convert.ToInt32(prodottoDaEliminare["Quantita"]);

        // Rimuovi il prodotto dal carrello
        carrello.Remove(prodottoDaEliminare);
        Console.WriteLine($"Prodotto '{nome}' rimosso dal carrello.");

        // Trova il prodotto nel catalogo per aggiornare la quantità disponibile
        var prodottoNelCatalogo = catalogo.FirstOrDefault(p => p.ContainsKey("Nome") && p["Nome"].ToString() == nome);

        if (prodottoNelCatalogo != null)
        {
            int quantitaCatalogo = Convert.ToInt32(prodottoNelCatalogo["Quantita"]);

            // Aggiungi la quantità del prodotto rimosso nel catalogo
            prodottoNelCatalogo["Quantita"] = quantitaCatalogo + quantitaDaRimuovere;
            Console.WriteLine($"La quantità del prodotto nel catalogo è stata aggiornata a {prodottoNelCatalogo["Quantita"]}.");

            // Scrivere le modifiche nel file JSON
            var catalogoJson = JsonConvert.SerializeObject(catalogo, Formatting.Indented);
            File.WriteAllText(fileCatalogo, catalogoJson); // Sovrascrivi il file JSON con il catalogo aggiornato
            Console.WriteLine("Catalogo aggiornato nel file.");
        }
        else
        {
            Console.WriteLine("Errore: prodotto non trovato nel catalogo.");
        }
    }
    else
    {
        Console.WriteLine($"Prodotto non trovato nel carrello.");
    }
}
```