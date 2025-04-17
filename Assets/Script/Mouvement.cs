using UnityEngine;

public class Mouvement : MonoBehaviour
{
    // Composant principale du joueur
    private PlayerInputReader _inputReader;
    private Rigidbody2D _rigidbody;
    private Collider2D _collider2D;
    public GameObject camera;
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
        camera = GameObject.FindWithTag("MainCamera");
        
        // S'abonner à l'événement sauter
        _inputReader.BS.callback += Sauter;
        _inputReader.LS_m.callback += Deplacer;
        
        // definir les vecteur a zero
        _directionDeplacement = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        // Deplacer camera
        camera.transform.position = new Vector2(camera.transform.position.x, transform.position.y);
        // Deplacement  
        _rigidbody.velocity = new Vector2(_directionDeplacement.x, _rigidbody.velocity.y );
    }   

    void Sauter()
    {
        Debug.Log("Sauter");
        RaycastHit2D[] hit = new RaycastHit2D[0];
        Debug.Log(_collider2D.Cast(Vector2.down, hit , 5f));
        if (_collider2D.Cast(Vector2.down, hit , 5f) > 0)
        {
            Debug.Log(_collider2D.Cast(Vector2.down, hit , 0.01f));
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, MagnitudeSaut);
        }
    }
    
    // Update quand un changement ce fait dans la valeur LS_m
    void Deplacer(Vector2 newDirection)
    {
        _directionDeplacement.x = newDirection.x * VitesseDeplacement;
    }
}
