using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouttonAjouter : MonoBehaviour
{
    public List<GameObject> objects;
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
