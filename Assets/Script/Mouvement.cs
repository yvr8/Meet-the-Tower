using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouvement : MonoBehaviour
{
    private PlayerInputReader inputReader;
    private Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        inputReader = GetComponent<PlayerInputReader>();
        // S'abonner à l'événement sauter
        inputReader.BS.callback += Sauter;
        inputReader.LS_m.callback += Deplacer;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * Time.deltaTime);
    }

    void Sauter()
    {
        Debug.Log("sauter");
    }
    void Deplacer(Vector2 newDirection)
    {
        direction = newDirection;
        Debug.Log(direction);
    }
}
