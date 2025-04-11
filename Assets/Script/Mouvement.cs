using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouvement : MonoBehaviour
{
    // Composant principale du joueur
    private PlayerInputReader _inputReader;
    private Vector2 _direction;
    private Rigidbody2D _rigidbody;
    // Variable modifiable pour changer le comportement du personnage
    public float MagnitudeSaut;
    public float MagnitudeDeplacement;
    public float VitesseDeplacementMax;
    // Variable utilise dans le script
    private 
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _inputReader = GetComponent<PlayerInputReader>();
        // S'abonner à l'événement sauter
        _inputReader.BS.callback += Sauter;
        _inputReader.LS_m.callback += Deplacer;
        
        _direction = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        _rigidbody.velocity = new Vector2(Mathf.Clamp(_rigidbody.velocity.x + _direction.x * MagnitudeDeplacement, -VitesseDeplacementMax, VitesseDeplacementMax), _rigidbody.velocity.y);
    }

    void Sauter()
    {
        _rigidbody.velocity = Vector2.up * MagnitudeSaut;
    }
    void Deplacer(Vector2 newDirection)
    {
        _direction.x = newDirection.x;
    }
}
