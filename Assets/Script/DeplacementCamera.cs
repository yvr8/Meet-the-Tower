using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeplacementCamera : MonoBehaviour
{
    public float ammortissement;
    private Vector2 _vector0;
    GameObject[] _joueurs;
    // Start is called before the first frame update
    void Start()
    {
        _joueurs = GameObject.FindGameObjectsWithTag("Player");
        _vector0 = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        DeplacerCamera();
    }

    void DeplacerCamera()
    {
        Vector3 pos = new Vector2();
        foreach (GameObject joueur in _joueurs)
        {
            pos += joueur.transform.position;
        }
        pos /= _joueurs.Length;
        
        transform.position = Vector2.SmoothDamp(transform.position, pos, ref _vector0, ammortissement );
    }
}
