using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiqueDynamique : PiqueStatique
{
    private SpriteRenderer _spriteRenderer;
    public bool _activated;
    public float distance;
    public float temps;
    private float _t;
    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _collider =  GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Animer();
    }

    void Activate()
    {
        new WaitForSecondsRealtime(1);
        
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
