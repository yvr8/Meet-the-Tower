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
    [Header("Menu Choisir Niveau")]
    public GameObject MenuChoisirNiveau;
    public TMP_Dropdown dropdownChoisirNiveau;

    void Start()
    {
        btnJouer.onClick.AddListener(btnJouer_onClick);
        btnParametre.onClick.AddListener(btnParametre_onClick);
        btnQuitter.onClick.AddListener(btnQuitter_onClick);

        dropdownChoisirNiveau.onValueChanged.AddListener(dropdownChoisirNiveauChange);
        
        MenuParametre.SetActive(false);
        MenuChoisirNiveau.SetActive(false);
    }
    void btnJouer_onClick()
    {
        MenuChoisirNiveau.SetActive(true);
        Menu.SetActive(false);
        Debug.Log("Jouer!");
    }
    void btnParametre_onClick()
    {
        MenuParametre.SetActive(true);
        Menu.SetActive(false);
        Debug.Log("Paramtre!");
    }
    void btnQuitter_onClick()
    {
        Debug.Log("Bye!");
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
