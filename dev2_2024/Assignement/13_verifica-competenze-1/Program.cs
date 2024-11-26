
public static List<string> rubrica = new List<string>();

static void Main()
{
    bool continua = true;

    while (continua)
    {
        Console.WriteLine("Scegli un'operazione:");
        Console.WriteLine("1. Aggiungi un contatto");
        Console.WriteLine("2. Visualizza tutti i contatti");
        Console.WriteLine("3. Esci");

        string scelta = Console.ReadLine();

        switch (scelta)
        {
            case "1":
                AggiungiContatto();
                break;
            case "2":
                VisualizzaContatti();
                break;
            case "3":
                continua = false;
                break;
            default:
                Console.WriteLine("Scelta non valida.");
                break;
        }
    }
}

// Funzione per aggiungere un contatto
static void AggiungiContatto()
{
    Console.WriteLine("Inserisci il nome del contatto:");
    string nome = Console.ReadLine();

    Console.WriteLine("Inserisci il cognome del contatto:");
    string cognome = Console.ReadLine();

    rubrica.Add(nome + " " + cognome);  // Aggiungi il contatto come stringa (Nome Cognome)

    Console.WriteLine("Contatto aggiunto!");
}

// Funzione per visualizzare tutti i contatti
static void VisualizzaContatti()
{
    if (rubrica.Count == 0)
    {
        Console.WriteLine("La rubrica è vuota.");
    }
    else
    {
        Console.WriteLine("Contatti nella rubrica:");
        foreach (string contatto in rubrica)
        {
            Console.WriteLine(contatto);
        }
    }
}
