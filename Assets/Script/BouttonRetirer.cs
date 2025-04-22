using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouttonRetirer : MonoBehaviour
{
    public List<GameObject> objects;
    private void OnTriggerEnter2D(Collider2D other)
    {
        foreach (GameObject obj in objects)
        {
            Debug.Log("Disabling: " + obj.name);
            obj.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        foreach (GameObject obj in objects)
        {
            Debug.Log("Enabling: " + obj.name);
            obj.SetActive(true);
        }
    }
}
