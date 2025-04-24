using System.Collections;
using System.Collections.Generic;
using UnityEditor.AssetImporters;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PiqueStatique : MonoBehaviour
{
    protected Collider2D _collider; 
    
    /// <summary>
    /// Initialise le composant Collider2D du pique statique.
    /// </summary>
    void Start()
    {
        _collider =  GetComponent<Collider2D>();
    }
    
    /// <summary>
    /// Détecte la collision avec le joueur et lui inflige des dégâts via une force d’éjection.
    /// </summary>
    /// <param name="collision">Le collider de l'objet entrant en contact avec le pique.</param>
    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Mouvement scriptJoueur = collision.gameObject.GetComponent<Mouvement>();
            scriptJoueur.SubirDegats(new Vector2(Random.Range(-1000, 1000), 2000 ));
        }
    }
} 
