using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoueurEtoileCollector : MonoBehaviour
{
    // Gestionnaire des étoiles
    private EtoileManager etoileManager;

    /// <summary>
    /// Récupère une référence au script EtoileManager au démarrage du jeu.
    /// </summary>
    void Start()
    {
        etoileManager = FindObjectOfType<EtoileManager>();
    }

    /// <summary>
    /// Déclenche la collecte d'une étoile lorsque le joueur entre en collision avec un objet tagué "Etoile".
    /// Ajoute une étoile au compteur et détruit l'objet collecté.
    /// </summary>
    /// <param name="other">Le collider de l'objet avec lequel le joueur entre en collision.</param>
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Etoile"))
        {
            etoileManager.AddStar();
            Destroy(other.gameObject);
        }
    }
}
