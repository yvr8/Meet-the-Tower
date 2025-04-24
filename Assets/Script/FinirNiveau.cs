using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinNiveauBouton : MonoBehaviour
{
    public Button btnRetourMenu;
    private ChronoManager chronoManager;  // Référence au ChronoManager
    public string tagEtoile = "Etoile";      // Tag utilisé pour les étoiles

    void Start()
    {
        // Recherche du ChronoManager dans la scène
        chronoManager = FindObjectOfType<ChronoManager>();

        if (btnRetourMenu != null)
        {
            btnRetourMenu.onClick.AddListener(FinirNiveau);
        }
    }

    void FinirNiveau()
    {
        Debug.Log("FinirNiveau");

        float tempsActuel = chronoManager.GetTime();
        bool toutesEtoilesRecupereesMaintenant = VerifierToutesLesEtoilesRecuperees();
        string nomNiveau = SceneManager.GetActiveScene().name;

        DonneesNiveau donneesExistantes = SystemeSauvegarde.Instance.GetNiveau(nomNiveau);

        bool garderEtoiles = toutesEtoilesRecupereesMaintenant;
        float tempsFinal = tempsActuel;

        if (donneesExistantes != null)
        {
            // Garder les étoiles si elles ont été récupérées avant
            if (donneesExistantes.toutesPiecesRecuperees)
                garderEtoiles = true;

            // Garder le meilleur temps (le plus petit)
            if (donneesExistantes.tempsUtilise < tempsActuel)
                tempsFinal = donneesExistantes.tempsUtilise;
        }

        SystemeSauvegarde.Instance.MettreAJourNiveau(
            nomNiveau,
            true,
            garderEtoiles,
            tempsFinal
        );

        // Retourner au menu
        RetourAcceuil();
    }

    bool VerifierToutesLesEtoilesRecuperees()
    {
        // Rechercher tous les objets avec le tag "Star"
        GameObject[] etoiles = GameObject.FindGameObjectsWithTag(tagEtoile);

        // Si le nombre d'étoiles dans la scène est égal à 0, alors toutes les étoiles sont récupérées
        return etoiles.Length == 0;
    }

    void RetourAcceuil()
    {
        // Charger la scène d'accueil
        SceneManager.LoadScene(sceneName: "Acceuil");
    }
}
