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
                "Terminé : " + (data.niveauTermine) + "\n" +
                "Toutes les pièces : " + (data.toutesPiecesRecuperees) + "\n" +
                "Temps utilisé : " + data.tempsUtilise.ToString("F2") + " sec";
        }
        else
        {
            texteAffichage.text = "Aucune donnée pour Niveau 1";
        }

        Debug.Log("Données niveau 1 : " + (data != null ? JsonUtility.ToJson(data) : "null"));
    }

}
