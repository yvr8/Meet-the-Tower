using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UIElements;

public class ControllerPiques : MonoBehaviour
{   
    // Temps avant de démmarer l'animation  
    public float waitBeforeStart = 2f;
    // Temps entre les animations
    public float repeatRate = 10f;
    // Delay entre l'activation de chaque pique dans l'animation de vague / vitesse de déplacement de la vague
    public float delayVague = 0.5f;
    // Liste de la sequance d'animation
    public enumStatePique[] statePique;
    // Index pour la suite d'animation fait par les piques
    private int index;
    // Enum pour les states de l'animation utilisable dans l'inspecteur d'Unity.
    public enum enumStatePique
    {
        All,
        Right,
        Left,
        Vague,
        Split11,
        Split22,
        Split33,
        Split44,
        Split11Reverse,
        Split22Reverse,
        Split33Reverse,
        Split44Reverse,
    } 
    // Liste des piques généré automatiquement quand ils sont mis dans un gameobject.
    private PiqueDynamique[] listePique;
    
    /// <summary>
    /// Initialise la liste des piques enfants et commence l'exécution répétée du contrôleur d'état après un délai défini.
    /// </summary>
    void Start()    
    {
        listePique = GetComponentsInChildren<PiqueDynamique>();
        InvokeRepeating("StateController", waitBeforeStart, repeatRate);
    }

    /// <summary>
    /// Contrôle la séquence des animations des piques en fonction de l'état défini dans le tableau statePique.
    /// Réinitialise l'index si la fin de la liste est atteinte.
    /// </summary>
    void StateController()
    {
        if (index >= statePique.Length)
        {
            index = 0;
        }

        switch (statePique[index])
        {
            case enumStatePique.All:
                All();
                break;
            case enumStatePique.Right:
                Side(false);
                break;
            case enumStatePique.Left:
                Side(true);
                break;
            case enumStatePique.Vague:
                StartCoroutine(Vague());
                break;
            case enumStatePique.Split11:
                Split(1, 1, false);
                break;
            case enumStatePique.Split22:
                Split(2, 2, false);
                break;
            case enumStatePique.Split33:
                Split(3, 3, false);
                break;
            case enumStatePique.Split44:
                Split(4, 4, false);
                break;
            case enumStatePique.Split11Reverse:
                Split(1, 1, true);
                break;
            case enumStatePique.Split22Reverse:
                Split(2, 2, true);
                break;
            case enumStatePique.Split33Reverse:
                Split(3, 3, true);
                break;
            case enumStatePique.Split44Reverse:
                Split(4, 4, true);
                break;
        }
        index++;
    }

    /// <summary>
    /// Active tous les piques de la liste simultanément.
    /// </summary>
    private void All()
    {
        foreach (PiqueDynamique pique in listePique)
        {
            pique.Activate();
        }
    }

    /// <summary>
    /// Active uniquement les piques du côté droit ou gauche selon le paramètre reverse.
    /// </summary>
    /// <param name="reverse">Si vrai, active le côté gauche ; sinon, active le côté droit.</param>
    private void Side(bool reverse)
    {
        int centre = listePique.Length / 2;

        for (int i = 0; i < listePique.Length; i++)
        {
            if (i >= centre)
            {
                if (!reverse)
                listePique[i].Activate();
            }
            else
            {
                if (reverse)
                    listePique[i].Activate();
            }
        }
    }
    
    /// <summary>
    /// Active les piques un par un en suivant une séquence avec un délai entre chaque activation.
    /// </summary>
    /// <returns>Coroutine IEnumerator pour permettre le délai entre les activations.</returns>
    private IEnumerator Vague()
    {
        foreach (PiqueDynamique pique in listePique)
        {
            pique.Activate();
            yield return new WaitForSeconds(delayVague);
        }
    }

    /// <summary>
    /// Active les piques en alternant des groupes définis par groupSize1 et groupSize2. L'ordre peut être inversé.
    /// </summary>
    /// <param name="groupSize1">Nombre de piques dans le premier groupe.</param>
    /// <param name="groupSize2">Nombre de piques dans le deuxième groupe.</param>
    /// <param name="reverse">Si vrai, active le groupe 1 au lieu du groupe 2.</param>
    private void Split(int groupSize1, int groupSize2, bool reverse)
    {
        int longeurCycle = groupSize1 + groupSize2;

        for (int i = 0; i < listePique.Length; i++)
        {
            int positionCycle = i % longeurCycle;

            if (positionCycle >= groupSize1)
            {
                if (!reverse)
                    listePique[i].Activate();
            }
            else if(positionCycle < groupSize1)
            {
                if(reverse)
                    listePique[i].Activate();
            }
        }
    }
}