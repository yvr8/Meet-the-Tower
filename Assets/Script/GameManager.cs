using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 1 sur x pique sera actif
    const int denominateur = 5;
    
    // Start is called before the first frame update
    void Start()
    {
        return;
        
        // 1 pique dynamique sur 2 aura des effets sonores
        PiqueDynamique[] piques = FindObjectsOfType<PiqueDynamique>();

        int index = 0;

        foreach (var pique in piques)
        {
            if (index > denominateur)
                index = 1;
            
            pique.sfxActive = index == denominateur;
            
            index++;
            
            
        }
    }
}
