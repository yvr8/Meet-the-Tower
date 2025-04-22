using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
