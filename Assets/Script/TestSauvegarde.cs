using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TestSauvegarde : MonoBehaviour
{
    public TextMeshProUGUI texteAffichage;

    void Start()
    {
        var data = SystemeSauvegarde.Instance.GetNiveau("Niveau1");

        if (data != null)
        {
            texteAffichage.text =
                "Niveau 1\n" +
                "Termin� : " + (data.niveauTermine) + "\n" +
                "Toutes les pi�ces : " + (data.toutesPiecesRecuperees) + "\n" +
                "Temps utilis� : " + data.tempsUtilise.ToString("F2") + " sec";
        }
        else
        {
            texteAffichage.text = "Aucune donn�e pour Niveau 1";
        }

        Debug.Log("Donn�es niveau 1 : " + (data != null ? JsonUtility.ToJson(data) : "null"));
    }

}
