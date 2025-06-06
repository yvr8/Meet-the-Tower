using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Composant principale du joueur
    private PlayerInputReader _inputReader;
    private Rigidbody2D _rigidbody;
    private Collider2D _collider2D;
    private List<ContactPoint2D> _contacts;
    AudioSource source;
    
    // Variable modifiable pour changer le comportement du personnage
    public float MagnitudeSaut;
    public float VitesseDeplacement;
    // Variable utilise dans le script
    private Vector2 _vecteurVelocite;
    private Vector2 _directionDeplacement;
    // Le menu de parametre
    public GameObject menu;
    private bool isMenuTrigger = false;
    // Effet a la mort
    public Image flashRouge;
    private float flashtime = 2f;
    
    [SerializeField] AudioClip clipSaut;
    [SerializeField] AudioClip clipAterissage;
    [SerializeField] AudioClip clipMort;
    
    /// <summary>
    /// Initialise les composants nécessaires du joueur et s'abonne aux événements d'entrée.
    /// </summary>
    void Start()
    {
        Time.timeScale = 1f;
        // Definir les composants de base
        _collider2D = GetComponent<Collider2D>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _inputReader = GetComponent<PlayerInputReader>();
        source = GetComponent<AudioSource>();
        
        // S'abonner à l'événement sauter
        _inputReader.BS.callback += Sauter;
        _inputReader.LS_m.callback += Deplacer;
        _inputReader.Menu.callback += Menu;
        // Initialiser les valeurs par default
        _directionDeplacement = Vector2.zero;
        _contacts = new List<ContactPoint2D>();
        menu.SetActive(false);

    }

    /// <summary>
    // /// Met à jour la vélocité horizontale du joueur à chaque frame selon la direction actuelle.
    // /// </summary>
    void Update()
    {
        // Deplacement  
        _rigidbody.velocity = new Vector2(_directionDeplacement.x, _rigidbody.velocity.y );
    }   
    void Menu()
    {
        
        isMenuTrigger = !isMenuTrigger;
        menu.SetActive(isMenuTrigger);
        if (isMenuTrigger){
            Time.timeScale = 0f;
        }
        else{
            Time.timeScale = 1f;
        }
    }
    /// <summary>
    /// Permet au joueur de sauter uniquement s'il est en contact avec le sol (vérification par angle de contact).
    /// </summary>
    void Sauter()
    {
        if (MagnitudeSaut < 0.1f)
            return;
        
        if (!_collider2D)
        {
            return;
        }
        _collider2D.GetContacts(_contacts);
        
        foreach (ContactPoint2D contact in _contacts)
        {
            float angleVersBas = Vector2.Angle(contact.normal, Vector2.up);
            
            if (angleVersBas < 15f)
            {
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);
                _rigidbody.AddForce(Vector2.up * MagnitudeSaut, ForceMode2D.Impulse);
                
                // Audio
                source.PlayOneShot(clipSaut);
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
        
        // audio mort
        source.PlayOneShot(clipMort);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // Récupérer la force de l'impact (10-20)
        float forceImpact = other.relativeVelocity.magnitude;

        // Aucun son si l'impact est minime
        if (forceImpact < 5)
            return;
        
        // Calculer la force du volume
        float volume = Utilites.remapper(forceImpact, 10f, 20f, 0.25f, 1f);
        
        // Jouer l'effet sonore au volume correspondant à l'impact
        source.PlayOneShot(clipAterissage, volume);
    }

    /// <summary>
    /// Sauvegarde l'état du niveau et prépare le redémarrage de la scène.
    /// </summary>
    private void FinirNiveau()
    {
        StartCoroutine(SequenceMortComplete());
    }

    private IEnumerator SequenceMortComplete()
    {
        // Lancer le flash
        yield return StartCoroutine(FlashRouge());

        // Recharger la scène
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private IEnumerator FlashRouge()
    {
        Time.timeScale = 0f;
        float duration = flashtime;
        float t = 0f;

        while (t < duration / 2f)
        {
            t += Time.unscaledDeltaTime;
            float alpha = Mathf.Lerp(0f, 0.5f, t / (duration / 2f));
            flashRouge.color = new Color(1f, 0f, 0f, alpha);
            yield return null;
        }

        t = 0f;

        while (t < duration / 2f)
        {
            t += Time.unscaledDeltaTime;
            float alpha = Mathf.Lerp(0.5f, 0f, t / (duration / 2f));
            flashRouge.color = new Color(1f, 0f, 0f, alpha);
            yield return null;
        }

        flashRouge.color = new Color(1f, 0f, 0f, 0f);
        
    }
}
