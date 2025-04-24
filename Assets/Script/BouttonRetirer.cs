using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouttonRetirer : MonoBehaviour
{
    // objets à désactiver / activer
    public List<GameObject> objects;
    
    /// <summary>
    /// Désactive tous les objets de la liste lorsque n'importe quel objet entre dans la zone de déclenchement, et affiche un message de log pour chaque désactivation.
    /// </summary>
    /// <param name="other">Le collider de l'objet entrant dans la zone de déclenchement.</param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        foreach (GameObject obj in objects)
        {
            Debug.Log("Disabling: " + obj.name);
            obj.SetActive(false);
        }
    }

    /// <summary>
    /// Réactive tous les objets de la liste lorsque n'importe quel objet sort de la zone de déclenchement, et affiche un message de log pour chaque activation.
    /// </summary>
    /// <param name="other">Le collider de l'objet sortant de la zone de déclenchement.</param>
    private void OnTriggerExit2D(Collider2D other)
    {
        foreach (GameObject obj in objects)
        {
            Debug.Log("Enabling: " + obj.name);
            obj.SetActive(true);
        }
    }
}
