using System.Collections.Generic;
using UnityEngine;

public class BouttonController : MonoBehaviour
{
    // objets à désactiver / activer
    public List<GameObject> objects;
    public bool reverse;
    public bool enableOnExit = true;
    
    AudioSource source;
    
    [SerializeField] AudioClip clipPressed;
    [SerializeField] AudioClip clipRelease;

    private bool isTriggered;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        
        foreach (GameObject obj in objects)
        {
            obj.SetActive(reverse);
        }
    }
    
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            foreach (GameObject obj in objects)
            {
                if (obj != null)
                {
                    obj.SetActive(!reverse);
                }
            }
            
            // Audio
            if (!isTriggered)
                source.PlayOneShot(clipPressed);

            isTriggered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player") && enableOnExit)
        {
            Debug.Log("Exit");
            
            foreach (GameObject obj in objects)
            {
                if (obj != null)
                {
                    obj.SetActive(reverse);
                }
            }
            
            // Audio
            source.PlayOneShot(clipRelease);

            isTriggered = false;
        }
    }
}