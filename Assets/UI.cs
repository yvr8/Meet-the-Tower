using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    [Header("Menu de base")]
    public GameObject Menu;
    public Button btnJouer;
    public Button btnParametre;
    public Button btnQuitter;
    [Header("Menu Parametre")]
    public GameObject MenuParametre;
    public Button btnRetourParametre;
    [Header("Menu Choisir Niveau")]
    public GameObject MenuChoisirNiveau;
    public Button btnRetour;
    public TMP_Dropdown dropdownChoisirNiveau;

    void Start()
    {
        //Menu de base
        btnJouer.onClick.AddListener(btnJouer_onClick);
        btnParametre.onClick.AddListener(btnParametre_onClick);
        btnQuitter.onClick.AddListener(btnQuitter_onClick);
        //Choix niveau
        btnRetour.onClick.AddListener(btnRetour_onClick);
        dropdownChoisirNiveau.onValueChanged.AddListener(dropdownChoisirNiveauChange);
        //Menu Parametre
        btnRetourParametre.onClick.AddListener(btnRetourParametre_onClick);
        
        MenuParametre.SetActive(false);
        MenuChoisirNiveau.SetActive(false);
    }
    void btnJouer_onClick()
    {
        MenuChoisirNiveau.SetActive(true);
        Menu.SetActive(false);
    }
    void btnRetour_onClick()
    {
        MenuChoisirNiveau.SetActive(false);
        Menu.SetActive(true);
    }
    void btnRetourParametre_onClick()
    {
        MenuParametre.SetActive(false);
        Menu.SetActive(true);
    }
    void btnParametre_onClick()
    {
        MenuParametre.SetActive(true);
        Menu.SetActive(false);
        Debug.Log("Paramtre!");
    }
    void btnQuitter_onClick()
    {
        Debug.Log("Quitter!");
        Application.Quit();
    }
    void dropdownChoisirNiveauChange(int index)
    {
        var niveau = dropdownChoisirNiveau.options[index].text;
        Debug.Log(niveau);
        if (niveau == "Choisir Niveau")
        {
            return;
        }
        else
        {
            Debug.Log(niveau);
            SceneManager.LoadScene(sceneName:niveau);
        }
    }

}
