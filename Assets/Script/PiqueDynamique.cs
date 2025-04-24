using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiqueDynamique : PiqueStatique
{
    // composants nécessaires pour le script défini automatiquement
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    
    
    private bool _activated;
    private float _t;
    // a changer dans unity afin d'avoir le resultat souaite.
    public float distance;
    public float temps;
    
    /// <summary>
    /// Initialise les composants nécessaires pour l’animation et les collisions du pique dynamique.
    /// </summary>
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _collider =  GetComponent<Collider2D>();
    }
    
    
    /// <summary>
    /// Appelé à chaque frame, déclenche le comportement animé du pique si activé.
    /// </summary>
    void Update()
    {
        Animer();
    }

    
    /// <summary>
    /// Lance la coroutine qui déclenche l'animation et l'activation du pique dynamique.
    /// </summary>
    public void Activate()
    {
        StartCoroutine(Coroutine());
    }
    
    /// <summary>
    // /// Coroutine qui démarre l'animation du pique, puis active son comportement après que l'animation de changement de couleur sois fini soit fini.
    // /// </summary>
    // /// <returns>Coroutine IEnumerator pour gérer l'attente avant l'activation.</returns>
    IEnumerator Coroutine()
    {
        _animator.SetTrigger("Activate");
        yield return new WaitForSeconds(1);
        _activated =  true;
    }

    
    /// <summary>
    /// Gère l'animation du pique en modifiant dynamiquement sa taille selon une fonction quadratique.
    /// Réinitialise après le temps défini.
    /// </summary>
    void Animer()
    {
        if (_activated)
        {
            _t += Time.deltaTime;
            _spriteRenderer.size = new Vector2(-4f * distance / (temps * temps) * _t * (_t - temps) + 2f, 1f);

            if (_t >= temps)
            {
                _t = 0;
                _spriteRenderer.size.Set(2f, 1f);
                _activated = false;
                
            }
        }
    }
}
