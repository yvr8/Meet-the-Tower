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
                "Termine : " + (data.niveauTermine) + "\n" +
                "Toutes les pieces : " + (data.toutesPiecesRecuperees) + "\n" +
                "Temps utilise : " + data.tempsUtilise.ToString("F2") + " sec";
        }
        else
        {
            texteAffichage.text = "Aucune donnee pour le Niveau 1";
        }

        Debug.Log("Donnees niveau 1 : " + (data != null ? JsonUtility.ToJson(data) : "null"));
    }

}
