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
    public Button btnNiveau1;
    public Button btnNiveau2;
    public Button btnNiveau3;
    public Button btnNiveau4;
    static bool personnageEstGenerer = false;
    void Start()
    {
        //Menu de base
        btnJouer.onClick.AddListener(btnJouer_onClick);
        btnParametre.onClick.AddListener(btnParametre_onClick);
        btnQuitter.onClick.AddListener(btnQuitter_onClick);
        //Choix niveau
        btnRetour.onClick.AddListener(btnRetour_onClick);
        //Menu Parametre
        btnRetourParametre.onClick.AddListener(btnRetourParametre_onClick);
        
        MenuParametre.SetActive(false);
        MenuChoisirNiveau.SetActive(false);
        btnNiveau1.onClick.AddListener(btnNiveau1_onClick);
        btnNiveau2.onClick.AddListener(btnNiveau2_onClick);
        btnNiveau3.onClick.AddListener(btnNiveau3_onClick);
        btnNiveau4.onClick.AddListener(btnNiveau4_onClick);
        if (!personnageEstGenerer)
        {
            personnageEstGenerer = true;
            SceneManager.LoadScene(sceneName: "Personnage", LoadSceneMode.Additive);
        }
        
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

    void btnNiveau1_onClick()
    {
        SceneManager.LoadScene(sceneName:"Niveau1");
    }
    void btnNiveau2_onClick()
    {
        SceneManager.LoadScene(sceneName:"Niveau2");
    }
    void btnNiveau3_onClick()
    {
        SceneManager.LoadScene(sceneName:"Niveau3");
    }
    void btnNiveau4_onClick()
    {
        SceneManager.LoadScene(sceneName:"Niveau4");
    }
}
