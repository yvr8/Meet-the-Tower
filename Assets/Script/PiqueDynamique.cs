using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiqueDynamique : PiqueStatique
{
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;
    private bool _activated;
    private float _t;
    // a changer dans unity afin d'avoir le resultat souaite.
    public float distance;
    public float temps;
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _collider =  GetComponent<Collider2D>();
    }
    
    void Update()
    {
        Animer();
    }

    public void Activate()
    {
        StartCoroutine(Coroutine());
    }
    
    // Activer le debut de l'animation et deplacement du pique dynamique.
    IEnumerator Coroutine()
    {
        _animator.SetTrigger("Activate");
        yield return new WaitForSeconds(1);
        _activated =  true;
    }

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
