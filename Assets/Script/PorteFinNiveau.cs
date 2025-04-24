using UnityEngine;
using UnityEngine.SceneManagement;

public class PorteFinNiveau : MonoBehaviour
{
    public int joueursRequis = 2;
    private int joueursPresents = 0;
    private bool niveauTermine = false;
    private ChronoManager chronoManager;
    public string tagEtoile = "Etoile";

    void Start()
    {
        chronoManager = FindObjectOfType<ChronoManager>();
        if (chronoManager == null)
        {
            return;
        }
    }

    void FinirNiveau()
    {
        float tempsActuel = chronoManager != null ? chronoManager.GetTime() : 0f;
        bool toutesEtoilesRecupereesMaintenant = VerifierToutesLesEtoilesRecuperees();
        string nomNiveau = SceneManager.GetActiveScene().name;

        DonneesNiveau donneesExistantes = SystemeSauvegarde.Instance.GetNiveau(nomNiveau);

        bool garderEtoiles = toutesEtoilesRecupereesMaintenant;
        float tempsFinal = tempsActuel;

        if (donneesExistantes != null)
        {
            if (donneesExistantes.toutesPiecesRecuperees)
                garderEtoiles = true;

            if (donneesExistantes.tempsUtilise > 0 && donneesExistantes.tempsUtilise < tempsActuel)
                tempsFinal = donneesExistantes.tempsUtilise;
        }

        SystemeSauvegarde.Instance.MettreAJourNiveau(
            nomNiveau,
            true,
            garderEtoiles,
            tempsFinal
        );

        RetourAcceuil();
    }

    bool VerifierToutesLesEtoilesRecuperees()
    {
        return GameObject.FindGameObjectsWithTag(tagEtoile).Length == 0;
    }

    void RetourAcceuil()
    {
        SceneManager.LoadScene("Acceuil");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            joueursPresents++;
            VerifierFin();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            joueursPresents--;
        }
    }

    void VerifierFin()
    {
        if (!niveauTermine && joueursPresents >= joueursRequis)
        {
            niveauTermine = true;
            FinirNiveau();
        }
    }
}
