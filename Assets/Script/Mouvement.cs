using System.Collections.Generic;
using UnityEngine;

public class Mouvement : MonoBehaviour
{
    // Composant principale du joueur
    private PlayerInputReader _inputReader;
    private Rigidbody2D _rigidbody;
    private Collider2D _collider2D;
    private List<ContactPoint2D> _contacts;
    // Variable modifiable pour changer le comportement du personnage
    public float MagnitudeSaut;
    public float VitesseDeplacement;
    // Variable utilise dans le script
    private Vector2 _vecteurVelocite;
    private Vector2 _directionDeplacement;
    void Start()
    {
        // Definir les composants de base
        _collider2D = GetComponent<Collider2D>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _inputReader = GetComponent<PlayerInputReader>();
        
        // S'abonner à l'événement sauter
        _inputReader.BS.callback += Sauter;
        _inputReader.LS_m.callback += Deplacer;
        
        // Initialiser les valeurs par default
        _directionDeplacement = Vector2.zero;
        _contacts = new List<ContactPoint2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Deplacement  
        _rigidbody.velocity = new Vector2(_directionDeplacement.x, _rigidbody.velocity.y );
    }   

    void Sauter()
    {
        
        _collider2D.GetContacts(_contacts);

        foreach (ContactPoint2D contact in _contacts)
        {
            float angleVersBas = Vector2.Angle(contact.normal, Vector2.up);
            
            if (angleVersBas < 15f)
            {
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);
                _rigidbody.AddForce(Vector2.up * MagnitudeSaut, ForceMode2D.Impulse);
                break;
            }
        }
    }
    
    // Update quand un changement ce fait dans la valeur LS_m
    void Deplacer(Vector2 newDirection)
    {
        _directionDeplacement.x = newDirection.x * VitesseDeplacement;
    }
    
    // Quand le joueur subit des degats, il est ejecte, font l'animation de mort et les joueurs retourner au checkpoint precedents.
    public void SubirDegats(Vector2 directionEjectionVector2)
    {
        _rigidbody.AddForce(directionEjectionVector2);
        Debug.Log("Recommencer la partie");
    }
    
}
