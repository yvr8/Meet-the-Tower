using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeplacementCamera : MonoBehaviour
{
    public float ammortissement;
    private Vector2 _vector0;
    private Camera _camera;
    private GameObject[] _joueurs;
    // Start is called before the first frame update
    void Start()
    {
        _joueurs = GameObject.FindGameObjectsWithTag("Player");
        _camera = GetComponent<Camera>();
        _vector0 = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCamera();
    }

    void UpdateCamera()
    {      
        // Deplace la camera sur la moyenne de la position des joueurs
        Vector3 pos = new Vector2();
         foreach (GameObject joueur in _joueurs)
         {
             pos += joueur.transform.position;
         }
         pos /= _joueurs.Length;
         
         transform.position = Vector2.SmoothDamp(transform.position, pos, ref _vector0, ammortissement );
         
         // Zoom la camera pour y inclure les deux joueurs
         _camera.orthographicSize = Mathf.Max(10f, Vector2.Distance(_joueurs[0].transform.position, _joueurs[1].transform.position) * 0.5f);
    }

}


  