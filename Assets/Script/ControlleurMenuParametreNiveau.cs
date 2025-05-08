using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ControlleurMenuParametreNiveau : MonoBehaviour
{
    public Button btnRetourParametre;
    public Button btnQuitter;
    public GameObject MenuParametre;
    // Start is called before the first frame update
    void Start()
    {
        btnRetourParametre.onClick.AddListener(btnRetourParametre_onClick);
        btnQuitter.onClick.AddListener(btnQuitter_onClick);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void btnQuitter_onClick()
    {
        SceneManager.LoadScene("Acceuil");
    }
    void btnRetourParametre_onClick()
    {
        Time.timeScale = 1f;
        MenuParametre.SetActive(false);
    }
}
