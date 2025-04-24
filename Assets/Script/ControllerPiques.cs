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
    public PiqueDynamique[] listePique;
    public float waitBeforeStart = 2f;
    public float repeatRate = 10f;
    public float delayVague = 0.5f;
    public enumStatePique[] statePique;

    //index pour la suite d'animation fait par les piques
    private int index;
    //enum pour les state d'animation.
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
    } 
    
    // Start is called before the first frame update
    void Start()    
    {
        listePique = GetComponentsInChildren<PiqueDynamique>();
        InvokeRepeating("StateController", waitBeforeStart, repeatRate);
    }

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
        }
        index++;
    }

    private void All()
    {
        foreach (PiqueDynamique pique in listePique)
        {
            pique.Activate();
        }
    }

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
    private IEnumerator Vague()
    {
        foreach (PiqueDynamique pique in listePique)
        {
            pique.Activate();
            yield return new WaitForSeconds(delayVague);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="groupeSize1">Nombre de pique dans le premier regroupement</param>
    /// <param name="groupeSize2">Nombre de pique dans le deuxieme regroupement</param>
    /// <param name="reverse">Inverse le groupe des piques qui sont active</param>
    /// <returns></returns>
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