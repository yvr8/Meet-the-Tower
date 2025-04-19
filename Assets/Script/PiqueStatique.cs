using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PiqueStatique : MonoBehaviour
{
    private TilemapCollider2D _tilemapCollider; 
    // Start is called before the first frame update
    void Start()
    {
        _tilemapCollider = GetComponent<TilemapCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Degats subis");
        }
    }
} 
