```csharp

using System.Net.Sockets; // using che da la funzionalità per la comunicazione in rete
using System.Text; // using che da le funzionalità per la gestione delle stringhe che vengono inviate e ricevute
using System.Threading; // using che da le funzionalità per la gestione dei thread cioè dei flussi di esecuzione separati

public class Server
{
    private TcpListener listener; // Oggetto che rappresenta un server TCP
    public void StartServer(int port)
    {
        listener = new TcpListener(IPAdress.Any, port); /// IPAddress.Any indica che il server accetta connessioni su tutte le interfacce di rete
        listener.Start(); // Avvia il server

        while (true)
        {
            // delegato un metodo che accetta un parametro singolo, passandogli direttamente il metodo come argomento new Parameterized costruttore del delegato
            TcpClient client = listener.AcceptTcpClient(); // Accetta una connessione da un client e restituisce un oggetto TcpClient che rappresenta il client connesso
            // Canale di connessione per un client specifico
            Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClient)); // Crea un nuovo thread per gestire il client connesso
            clientThread.Start(client); // Avvia il thread per gestire il client connesso in questo caso thread
        }
    }
}
```