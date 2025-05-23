using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeplacementCamera : MonoBehaviour
{
    // Valeur utilisé pour arrondir le déplacement de la caméra pour le rendre moins brutal
    public float ammortissement;
    // Velocité du deplacement de la caméra utilisé par Vector2.SmoothDamp()
    private Vector2 _velociteActuel;
    // Caméra à déplacer
    private Camera _camera;
    // les deux joueurs pour faire la moyenne de leurs positions
    private GameObject[] _joueurs;
    
    /// <summary>
    // /// Initialise les références aux joueurs et à la caméra au démarrage du script.
    // /// </summary>
    void Start()
    {
        _joueurs = GameObject.FindGameObjectsWithTag("Player");
        _camera = GetComponent<Camera>();
        _velociteActuel = Vector2.zero;
    }

    /// <summary>
    // /// Met à jour la position et le zoom de la caméra à chaque frame.
    // /// </summary>
    void Update()
    {
        UpdateCamera();
    }

    /// <summary>
    /// Centre la caméra sur la moyenne des positions des joueurs avec un effet d'amortissement,
    /// puis ajuste le zoom pour s'assurer que les deux joueurs sont visibles à l'écran.
    /// </summary>
    void UpdateCamera()
    {
        if (_joueurs.Length < 2) return;

        // Moyenne des positions
        Vector2 positionMoyenne = Vector2.zero;
        foreach (GameObject joueur in _joueurs)
            positionMoyenne += (Vector2)joueur.transform.position;

        positionMoyenne /= _joueurs.Length;

        transform.position = Vector2.SmoothDamp(transform.position, positionMoyenne, ref _velociteActuel, ammortissement);
        transform.position = new Vector3(transform.position.x, transform.position.y, -10f); // Garder un Z fixe

        Vector2 pos1 = _joueurs[0].transform.position;
        Vector2 pos2 = _joueurs[1].transform.position;

        float distanceX = Mathf.Abs(pos1.x - pos2.x) / _camera.aspect; // Adapter au ratio largeur/hauteur
        float distanceY = Mathf.Abs(pos1.y - pos2.y);

        float marge = 2f;

        _camera.orthographicSize = Mathf.Max(10f, (Mathf.Max(distanceX, distanceY) / 2f) + marge);
    }

}


  