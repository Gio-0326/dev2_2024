
public class DipendenteManager
{
    private int id; 
    private string username;
    private string ruolo;
    private List<Dipendente> dipendenti;


    public DipendenteManager( List<Dipendente> Dipendenti,int Id, string Username, string Ruolo)
    {
        id = Id;
        username = Username;
        ruolo = Ruolo;
        dipendenti = Dipendenti;

        id = 1;

        foreach (var dipendente in dipendenti)
        {
            if (dipendente.id >= id)
            {
                id = dipendente.id + 1;
            }
        }
    }

    public void AssegnaUsername()
    {

    }
}
