using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Mouvement : MonoBehaviour
{
    // Composant principale du joueur
    private PlayerInputReader _inputReader;
    private Rigidbody2D _rigidbody;
    public GameObject _camera;
    // Variable modifiable pour changer le comportement du personnage
    public float MagnitudeSaut;
    public float VitesseDeplacement;
    // Variable utilise dans le script
    private Vector2 _vecteurVelocite;
    private Vector2 _directionDeplacement;
    void Start()
    {
        // Definir les composants de base
        _rigidbody = GetComponent<Rigidbody2D>();
        _inputReader = GetComponent<PlayerInputReader>();
        _camera = GameObject.FindWithTag("MainCamera");
        // S'abonner à l'événement sauter
        _inputReader.BS.callback += Sauter;
        _inputReader.LS_m.callback += Deplacer;
        // definir les vecteur a zero
        _directionDeplacement = Vector2.zero;
        _vecteurVelocite = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        // Deplacer camera
        _camera.transform.position = new Vector2(_camera.transform.position.x, transform.position.y);
        // Deplacement  
        _vecteurVelocite = _rigidbody.velocity;
        _rigidbody.velocity = new Vector2(Mathf.Clamp(_directionDeplacement.x * VitesseDeplacement, -VitesseDeplacement, VitesseDeplacement), _vecteurVelocite.y) ;
    }

    void Sauter()
    {
        _rigidbody.AddForce(Vector2.up * MagnitudeSaut);
    }
    // Update quand un changement ce fait dans la valeur LS_m
    void Deplacer(Vector2 newDirection)
    {
        _directionDeplacement.x = newDirection.x;
    }
}
