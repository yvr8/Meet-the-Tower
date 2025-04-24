using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoueurEtoileCollector : MonoBehaviour
{
    private EtoileManager etoileManager;

    void Start()
    {
        etoileManager = FindObjectOfType<EtoileManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Etoile"))
        {
            etoileManager.AddStar();
            Destroy(other.gameObject);
        }
    }
}
