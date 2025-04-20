using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PiqueStatique : MonoBehaviour
{
    protected Collider2D _collider; 
    // Start is called before the first frame update
    void Start()
    {
        _collider =  GetComponent<Collider2D>();
    }
    
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Degats subis");
        }
    }
} 
