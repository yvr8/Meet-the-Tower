using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestionMusique : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip[] musiques;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.loop = false;
        JouerMusiqueAleatoire();

    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying)
        {
            JouerMusiqueAleatoire();
        }
    }
    void JouerMusiqueAleatoire()
    {
        if (musiques.Length == 0) return;

        AudioClip musique = musiques[UnityEngine.Random.Range(0, musiques.Length)];
        audioSource.clip = musique;
        audioSource.Play();
    }

}
