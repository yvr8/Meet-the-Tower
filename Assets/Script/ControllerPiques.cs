using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UIElements;

public class ControllerPiques : MonoBehaviour
{   
    public PiqueDynamique[] listePique;
    public float waitBeforeStart = 2f;
    public float repeatRate = 10f;
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
                Split(1, 1);
                break;
            case enumStatePique.Split22:
                Split(2, 2);
                break;
            case enumStatePique.Split33:
                Split(3, 3);
                break;
            case enumStatePique.Split44:
                Split(4, 4);
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
        int centre = listePique.Length - 1;
        // gauche -> droite
        if (!reverse)
        {
            for (int i = 0; i <= centre; i++)
            {
                listePique[i].Activate();
            }
        }
        // droit -> gauche
        else
        {
            for (int i = 0; i <= centre; i--)
            {
                listePique[i].Activate();
            }
        }
    }
    private IEnumerator Vague()
    {
        foreach (PiqueDynamique pique in listePique)
        {
            pique.Activate();
            yield return new WaitForSeconds(0.5f);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="groupeSize1">Nombre de pique dans le premier regroupement</param>
    /// <param name="groupeSize2">Nombre de pique dans le deuxieme regroupement</param>
    /// <param name="reverse">Inverse le groupe des piques qui sont active</param>
    /// <returns></returns>
    private void Split(int groupeSize1, int groupeSize2)
    {
        for (int i = 0; i < listePique.Length; i++)
        {
            if (groupeSize1 / (groupeSize1 + groupeSize2) <= i % (groupeSize1 + groupeSize2))
            {
                listePique[i].Activate();
            }
        }
    }
}