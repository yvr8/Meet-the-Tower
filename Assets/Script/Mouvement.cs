using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    
    /// <summary>
    /// Initialise les composants nécessaires du joueur et s'abonne aux événements d'entrée.
    /// </summary>
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

    /// <summary>
    // /// Met à jour la vélocité horizontale du joueur à chaque frame selon la direction actuelle.
    // /// </summary>
    void Update()
    {
        // Deplacement  
        _rigidbody.velocity = new Vector2(_directionDeplacement.x, _rigidbody.velocity.y );
    }   

    /// <summary>
    /// Permet au joueur de sauter uniquement s'il est en contact avec le sol (vérification par angle de contact).
    /// </summary>
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
    
    
    // /// <summary>
    // /// Met à jour la direction de déplacement horizontale selon l'entrée du joueur.
    // /// </summary>
    // /// <param name="newDirection">Nouvelle direction d'entrée sur l'axe X.</param>
    void Deplacer(Vector2 newDirection)
    {
        _directionDeplacement.x = newDirection.x * VitesseDeplacement;
    }
    
    /// <summary>
    /// Applique une force d’éjection au joueur, déclenche une animation de mort et relance le niveau après sauvegarde.
    /// </summary>
    /// <param name="directionEjectionVector2">Vecteur représentant la direction de l'éjection.</param>
    public void SubirDegats(Vector2 directionEjectionVector2)
    {
        _rigidbody.AddForce(directionEjectionVector2);
        Debug.Log("Recommencer la partie");
        FinirNiveau(); // Fonction pour sauvegarder 
    }
    
    /// <summary>
    /// Sauvegarde l'état du niveau et prépare le redémarrage de la scène.
    /// </summary>
    private void FinirNiveau()
    {
        Debug.Log("FinirNiveau");
        string nomNiveau = SceneManager.GetActiveScene().name;

        SystemeSauvegarde.Instance.MettreAJourNiveau(
            nomNiveau,
            true,
            false,
            22f
        );
        StartCoroutine(RelancerLaScene()); // Relancer la scene (fonction au cas ou on ajoute autre chose)
    }

    /// <summary>
    /// Attend un court délai avant de recharger la scène actuelle.
    /// </summary>
    /// <returns>Coroutine IEnumerator pour effectuer le délai avant relancement.</returns>
    private IEnumerator RelancerLaScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
