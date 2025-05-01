using System.Collections.Generic;
using UnityEngine;

public class BouttonController : MonoBehaviour
{
    // objets à désactiver / activer
    public List<GameObject> objects;
    public bool reverse;
    private bool triggered = false;
    private void Update()
    {
        if (triggered)
        {
            foreach (GameObject obj in objects)
            {
                obj.SetActive(reverse);
            }
            triggered = false;
        }
    }
    /// <summary>
    /// Désactive tous les objets de la liste lorsque le joueur entre dans la zone de déclenchement.
    /// </summary>
    /// <param name="col">Le collider de l'objet entrant dans la zone de déclenchement.</param>
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            triggered = true;
        }
    }
}