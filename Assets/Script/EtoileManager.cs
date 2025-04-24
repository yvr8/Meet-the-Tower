using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EtoileManager : MonoBehaviour
{
    public TMP_Text starTMPText;
    private int starsCollected = 0;
    void Start()
    {
        starTMPText.text = "Etoile : 0";
    }
    public void AddStar()
    {
        starsCollected++;
        starTMPText.text = "Etoile : " + starsCollected;
    }
}
