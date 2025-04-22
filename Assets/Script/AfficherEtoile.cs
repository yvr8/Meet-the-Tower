using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AfficherEtoile : MonoBehaviour
{
    [Header("Niveau1")]
    public Image N1Etoile1;
    public Image N1Etoile2;
    public Image N1Etoile3;
    [Header("Niveau2")]
    public Image N2Etoile1;
    public Image N2Etoile2;
    public Image N2Etoile3;
    [Header("Niveau3")]
    public Image N3Etoile1;
    public Image N3Etoile2;
    public Image N3Etoile3;
    [Header("Niveau4")]
    public Image N4Etoile1;
    public Image N4Etoile2;
    public Image N4Etoile3;
    
    void Start()
    {
        var dataNiveau1 = SystemeSauvegarde.Instance.GetNiveau("Niveau1");
        if (dataNiveau1 != null)
        {
            if (dataNiveau1.niveauTermine) {N1Etoile1.color = new Color(1, 200, 200, 1);}
            if (dataNiveau1.toutesPiecesRecuperees) {N1Etoile2.color = new Color(1, 200, 200, 1);}
            if (dataNiveau1.tempsUtilise<=60) {N1Etoile3.color = new Color(1, 200, 200, 1);}
        }
        
    }
}
