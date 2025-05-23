using System.Collections.Generic;
using UnityEngine;

public class BouttonController : MonoBehaviour
{
    // objets à désactiver / activer
    public List<GameObject> objects;
    public bool reverse;
    public bool enableOnExit = true;

    private void Start()
    {
        foreach (GameObject obj in objects)
        {
            obj.SetActive(reverse);
        }
    }
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            foreach (GameObject obj in objects)
            {
                if (obj != null)
                {
                    obj.SetActive(!reverse);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player") && enableOnExit)
        {
            foreach (GameObject obj in objects)
            {
                if (obj != null)
                {
                    obj.SetActive(reverse);
                }
            }
        }
    }
}