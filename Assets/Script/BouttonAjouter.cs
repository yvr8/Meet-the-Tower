using System.Collections.Generic;
using UnityEngine;

public class BouttonAjouter : MonoBehaviour
{
    // objets à désactiver / activer
    public List<GameObject> objects;
    
    /// <summary>
    /// Désactive tous les objets de la liste lorsque le joueur entre dans la zone de déclenchement.
    /// </summary>
    /// <param name="col">Le collider de l'objet entrant dans la zone de déclenchement.</param>
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            foreach (GameObject obj in objects)
            {
                obj.SetActive(false);
            }
        }
    }

    /// <summary>
    /// Réactive tous les objets de la liste lorsque le joueur sort de la zone de déclenchement.
    /// </summary>
    /// <param name="col">Le collider de l'objet sortant de la zone de déclenchement.</param>
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            foreach (GameObject obj in objects)
            {
                obj.SetActive(true);
            }
        }
    }
}
