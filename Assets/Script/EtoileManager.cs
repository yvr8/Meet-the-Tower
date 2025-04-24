using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EtoileManager : MonoBehaviour
{
    // Affichage en text du nombre d'étoile sur l'interface utilisateur
    public TMP_Text starTMPText;
    // Nombre d'étoiles collectés
    private int starsCollected = 0;
    
    /// <summary>
    /// Initialise l'affichage du texte des étoiles à 0 au démarrage du script.
    /// </summary>
    void Start()
    {
        starTMPText.text = "Etoile : 0";
    }
    
    /// <summary>
    /// Incrémente le nombre d'étoiles collectées et met à jour le texte affiché.
    /// </summary>
    public void AddStar()
    {
        starsCollected++;
        starTMPText.text = "Etoile : " + starsCollected;
    }
}
