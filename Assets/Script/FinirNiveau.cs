using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
// Ce code est le test lié au bouton, il est amené a disparaitre (la porte vas faire sa)
public class FinNiveauBouton : MonoBehaviour
{
    public bool toutesPiecesRecuperees = true;
    public float tempsUtilise = 75.312122f;
    public Button btnRetourMenu;      

    void Start()
    {
  
        if (btnRetourMenu != null)
        {
            btnRetourMenu.onClick.AddListener(FinirNiveau);
        }

    }

    void FinirNiveau()
    {
        Debug.Log("FinirNiveau");
        string nomNiveau = SceneManager.GetActiveScene().name;

        SystemeSauvegarde.Instance.MettreAJourNiveau(
            nomNiveau,
            true,
            toutesPiecesRecuperees,
            tempsUtilise
        );
        RetourAcceuil();
    }

    void RetourAcceuil()
    {
        SceneManager.LoadScene(sceneName: "Acceuil");
    }
}
