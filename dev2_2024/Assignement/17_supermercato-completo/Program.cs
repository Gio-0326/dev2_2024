
/*using Newtonsoft.Json; 

 
string FilePath = @"catalogo.json"; 
 
if (!Directory.Exists(FilePath)) 
{ 
    Directory.CreateDirectory(FilePath); 
} 
 
var catalogo = CaricaCatalogo(); // Carica il catalogo esistente o inizializza con prodotti di esempio 
var carrello = new List<Dictionary<string, object>>(); 
var scontrini = CaricaScontrini(); // Carica gli scontrini esistenti 
 
bool continua = true; 
 
Console.WriteLine("Sei un operatore o un cliente?"); 
Console.WriteLine("1. Operatore"); 
Console.WriteLine("2. Cliente"); 
Console.Write("Scegli un'opzione: "); 
 
string tipoUtente = Console.ReadLine(); 
 
while (continua) 
{ 
    if (tipoUtente == "1") // Operatore 
    { 
        Console.WriteLine("\n--- Menu Operatore ---"); 
        Console.WriteLine("1. Aggiungi prodotto al catalogo"); 
        Console.WriteLine("2. Visualizza catalogo"); 
        Console.WriteLine("3. Esci"); 
        Console.Write("Scegli un'opzione: "); 
 
        string sceltaOperatore = Console.ReadLine(); 
        switch (sceltaOperatore) 
        { 
            case "1": 
                AggiungiProdottoUI(catalogo); 
                break; 
 
            case "2": 
                VisualizzaCatalogo(catalogo); 
                break; 
 
            case "3": 
                continua = false; 
                Console.WriteLine("Arrivederci!"); 
                break; 
 
            default: 
                Console.WriteLine("Opzione non valida. Riprova."); 
                break; 
        } 
    } 
    else if (tipoUtente == "2") // Cliente 
    { 
        Console.WriteLine("\n--- Menu Cliente ---"); 
        Console.WriteLine("1. Aggiungi prodotto al carrello"); 
        Console.WriteLine("2. Visualizza carrello"); 
        Console.WriteLine("3. Genera e salva scontrino"); 
        Console.WriteLine("4. Visualizza storico scontrini"); 
        Console.WriteLine("5. Esci"); 
        Console.Write("Scegli un'opzione: "); 
 
        string sceltaCliente = Console.ReadLine(); 
        switch (sceltaCliente) 
        { 
            case "1": 
                AggiungiAlCarrelloUI(catalogo, carrello); 
                break; 
 
            case "2": 
                VisualizzaCarrello(carrello); 
                break; 
 
            case "3": 
                GeneraESalvaScontrino(carrello, scontrini); 
                break; 
 
            case "4": 
                VisualizzaScontrini(scontrini); 
                break; 
 
            case "5": 
                continua = false; 
                Console.WriteLine("Arrivederci!"); 
                break; 
 
            default: 
                Console.WriteLine("Opzione non valida. Riprova."); 
                break; 
        } 
    } 
    else 
    { 
        Console.WriteLine("Opzione non valida. Riprova."); 
        continua = false; 
    } 
} 
 
static void AggiungiProdottoUI(List<Dictionary<string, object>> catalogo) 
{ 
    Console.Write("Inserisci ID prodotto: "); 
    string id = Console.ReadLine(); 
 
    Console.Write("Inserisci nome prodotto: "); 
    string nome = Console.ReadLine(); 
 
    Console.Write("Inserisci prezzo prodotto: "); 
    string prezzo = Console.ReadLine(); 
 
    Console.Write("Inserisci quantità disponibile: "); 
    string quantita = Console.ReadLine(); 
 
    AggiungiProdotto(catalogo, id, nome, prezzo, quantita); 
    Console.WriteLine($"Prodotto \"{nome}\" aggiunto al catalogo."); 
    string catalogoPathJson = @"./Json/catalogo.json"; 
 
    List<Dictionary<string, object>> catalogoEsistente = new List<Dictionary<string, object>>(); 
 
    if (File.Exists(catalogoPathJson)) 
    { 
        string jsonCatalogo = File.ReadAllText(catalogoPathJson); 
 
        try 
        { 
            var prodotto = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonCatalogo); 
            catalogoEsistente.Add(prodotto); 
        } 
        catch (JsonException) 
        { 
            catalogoEsistente = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(jsonCatalogo); 
        } 
    } 
 
    catalogoEsistente.Add(new Dictionary<string, object> 
    { 
        { "Id", id }, 
        { "Nome", nome }, 
        { "Prezzo", prezzo }, 
        { "Quantita", quantita } 
    }); 
 
    File.WriteAllText(catalogoPathJson, JsonConvert.SerializeObject(catalogoEsistente, Formatting.Indented)); 
} 
 
static void AggiungiProdotto(List<Dictionary<string, object>> catalogo, string id, string nome, string prezzo, string quantita) 
{ 
    catalogo.Add(new Dictionary<string, object> 
    { 
        { "Id", id }, 
        { "Nome", nome }, 
        { "Prezzo", prezzo }, 
        { "Quantita", quantita } 
    }); 
} 
 
static void VisualizzaCatalogo(List<Dictionary<string, object>> catalogo) 
{ 
    if (catalogo == null || catalogo.Count == 0) 
    { 
        Console.WriteLine("Il catalogo è vuoto."); 
        return; 
    } 
 
    Console.WriteLine("--- Catalogo Prodotti ---"); 
    foreach (var prodotto in catalogo) 
    { 
        // Controlla se la chiave "Id" esiste nel dizionario 
        if (prodotto.ContainsKey("Id") && prodotto.ContainsKey("Nome") && prodotto.ContainsKey("Prezzo") && prodotto.ContainsKey("Quantita")) 
        { 
            Console.WriteLine($"Id: {prodotto["Id"]}, Nome: {prodotto["Nome"]}, Prezzo: {prodotto["Prezzo"]}, Quantità: {prodotto["Quantita"]}"); 
        } 
        else 
        { 
            Console.WriteLine("Errore: Prodotto incompleto nel catalogo."); 
        } 
    } 
} 
 
 
static void AggiungiAlCarrelloUI(List<Dictionary<string, object>> catalogo, List<Dictionary<string, object>> carrello) 
{ 
    Console.Write("Inserisci ID prodotto: "); 
    string id = Console.ReadLine(); 
 
    Console.Write("Inserisci quantità: "); 
    string quantita = Console.ReadLine(); 
 
    AggiungiAlCarrello(catalogo, carrello, id, quantita); 
} 
 
static void AggiungiAlCarrello(List<Dictionary<string, object>> catalogo, List<Dictionary<string, object>> carrello, string id, string quantita) 
{ 
    var prodotto = catalogo.FirstOrDefault(p => p["Id"] == id); 
 
    if (prodotto == null) 
    { 
        Console.WriteLine($"Prodotto con Id {id} non trovato."); 
        return; 
    } 
 
    if (int.Parse(prodotto["Quantita"].ToString()) < int.Parse(quantita)) 
    { 
        Console.WriteLine($"Quantità non disponibile per il prodotto {prodotto["Nome"]}."); 
        return; 
    } 
 // Aggiorna il catalogo
    prodotto["Quantita"] = (int.Parse(prodotto["Quantita"].ToString()) - int.Parse(quantita)).ToString(); 
 // Aggiungi al carrello
    carrello.Add(new Dictionary<string, object> 
    { 
        { "Nome", prodotto["Nome"] }, 
        { "Prezzo", prodotto["Prezzo"] }, 
        { "Quantita", quantita }, 
        { "Totale", (Convert.ToDouble(prodotto["Prezzo"]) * int.Parse(quantita)).ToString("F2") } 
    }); 
 
    Console.WriteLine($"Prodotto \"{prodotto["Nome"]}\" aggiunto al carrello."); 
} 
 
static void VisualizzaCarrello(List<Dictionary<string, object>> carrello) 
{ 
    if (carrello.Count == 0) 
    { 
        Console.WriteLine("Il carrello è vuoto."); 
        return; 
    } 
 
    Console.WriteLine("--- Carrello ---"); 
    foreach (var item in carrello) 
    { 
        Console.WriteLine($"{item["Nome"]} x{item["Quantita"]} - Totale: {Convert.ToDouble(item["Totale"]):C2}"); 
    } 
} 
 
static void GeneraESalvaScontrino(List<Dictionary<string, object>> carrello, List<Dictionary<string, object>> scontrini) 
{ 
    if (carrello.Count == 0) 
    { 
        Console.WriteLine("Il carrello è vuoto. Aggiungi prodotti prima di generare lo scontrino."); 
        return; 
    } 
 
    var scontrino = GeneraScontrino(carrello); 
    scontrini.Add(scontrino); 
    carrello.Clear(); 
 
    Console.WriteLine("Scontrino generato e salvato."); 
    SalvaScontrino(scontrino);  // Salva lo scontrino nel file JSON 
    VisualizzaScontrino(scontrino); 
} 
 
static Dictionary<string, object> GeneraScontrino(List<Dictionary<string, object>> carrello) 
{ 
    double totale = carrello.Sum(item => Convert.ToDouble(item["Totale"])); 
 
    return new Dictionary<string, object> 
    { 
        { "DataAcquisto", DateTime.Now.ToString() }, 
        { "ProdottiAcquistati", string.Join("; ", carrello.Select(item => $"{item["Nome"]} x{item["Quantita"]} ({item["Totale"]})")) }, 
        { "TotaleSpesa", totale.ToString("F2") } 
    }; 
} 
 
static void VisualizzaScontrino(Dictionary<string, object> scontrino) 
{ 
    Console.WriteLine($"Data: {scontrino["DataAcquisto"]}"); 
    Console.WriteLine($"Prodotti Acquistati: {scontrino["ProdottiAcquistati"]}"); 
    Console.WriteLine($"Totale Scontrino: {scontrino["TotaleSpesa"]:C2}"); 
} 
 
static void VisualizzaScontrini(List<Dictionary<string, object>> scontrini) 
{ 
    if (scontrini.Count == 0) 
    { 
        Console.WriteLine("Nessuno scontrino trovato."); 
        return; 
    } 
 
    foreach (var scontrino in scontrini) 
    { 
        VisualizzaScontrino(scontrino); 
        Console.WriteLine("---------------"); 
    } 
} 
 
static void SalvaScontrino(Dictionary<string, object> scontrino) 
{ 
    string scontriniPathJson = @"scontrini.json"; 
 
    List<Dictionary<string, object>> scontriniEsistenti = CaricaScontrini(); 
 
    scontriniEsistenti.Add(scontrino); 
 
    File.WriteAllText(scontriniPathJson, JsonConvert.SerializeObject(scontriniEsistenti, Formatting.Indented)); 
} 
 
static List<Dictionary<string, object>> CaricaScontrini() 
{ 
    string scontriniPathJson = @"scontrini.json"; 
    if (File.Exists(scontriniPathJson)) 
    { 
        string jsonScontrini = File.ReadAllText(scontriniPathJson); 
        return JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(jsonScontrini); 
    } 
    return new List<Dictionary<string, object>>(); // Se non esistono scontrini, ritorna una lista vuota 
} 
 
static List<Dictionary<string, object>> CaricaCatalogo() 
{ 
    string catalogoPathJson = @"catalogo.json"; 
    if (File.Exists(catalogoPathJson)) 
    { 
        string jsonCatalogo = File.ReadAllText(catalogoPathJson); 
        return JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(jsonCatalogo); 
    } 
    else 
    { 
        // Popola il catalogo con alcuni prodotti predefiniti 
        return PopolaCatalogo(); 
    } 
} 
 
static List<Dictionary<string, object>> PopolaCatalogo() 
{ 
    return new List<Dictionary<string, object>>() 
    { 
        new Dictionary<string, object> { { "Id", "001" }, { "Nome", "Pane" }, { "Prezzo", "1,50" }, { "Quantita", "100" } }, 
        new Dictionary<string, object> { { "Id", "002" }, { "Nome", "Latte" }, { "Prezzo", "0,99" }, { "Quantita", "50" } }, 
        new Dictionary<string, object> { { "Id", "003" }, { "Nome", "Mela" }, { "Prezzo", "2,00" }, { "Quantita", "200" } } 
    }; 
}*/


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

    Console.Write("Inserisic il nome del prodotto:");
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