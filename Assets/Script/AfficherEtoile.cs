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
            if (dataNiveau1.niveauTermine) {N1Etoile1.color = new Color(1, 1, 1, 1);}
            if (dataNiveau1.toutesPiecesRecuperees) {N1Etoile2.color = new Color(1, 1, 1, 1);}
            if (dataNiveau1.tempsUtilise<=120) {N1Etoile3.color = new Color(1, 1, 1, 1);}
        }
        var dataNiveau2 = SystemeSauvegarde.Instance.GetNiveau("Niveau2");
        if (dataNiveau2 != null)
        {
            if (dataNiveau2.niveauTermine) {N2Etoile2.color = new Color(1, 1, 1, 1);}
            if (dataNiveau2.toutesPiecesRecuperees) {N2Etoile3.color = new Color(1, 1, 1, 1);}
            if (dataNiveau2.tempsUtilise<=250) {N2Etoile3.color = new Color(1, 1, 1, 1);}
        }
        var dataNiveau3 = SystemeSauvegarde.Instance.GetNiveau("Niveau3");
        if (dataNiveau3 != null)
        {
            if (dataNiveau3.niveauTermine) {N3Etoile1.color = new Color(1, 1, 1, 1);}
            if (dataNiveau3.toutesPiecesRecuperees) {N3Etoile2.color = new Color(1, 1, 1, 1);}
            if (dataNiveau3.tempsUtilise<=375) {N3Etoile3.color = new Color(1, 1, 1, 1);}
        }
        var dataNiveau4 = SystemeSauvegarde.Instance.GetNiveau("Niveau4");
        if (dataNiveau4 != null)
        {
            if (dataNiveau4.niveauTermine) {N4Etoile1.color = new Color(1, 1, 1, 1);}
            if (dataNiveau4.toutesPiecesRecuperees) {N4Etoile2.color = new Color(1, 1, 1, 1);}
            if (dataNiveau4.tempsUtilise<=400) {N4Etoile3.color = new Color(1, 1, 1, 1);}
        }
    }
}
