using System.IO;
using UnityEngine;
using System.Collections.Generic;

public class SystemeSauvegarde : MonoBehaviour
{
    public static SystemeSauvegarde Instance;

    public SauvegardeJeu sauvegarde = new SauvegardeJeu();
    private string chemin => Application.persistentDataPath + "/sauvegarde.json";

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Charger();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Sauvegarder()
    {
        string json = JsonUtility.ToJson(sauvegarde, true);
        File.WriteAllText(chemin, json);
    }

    public void Charger()
    {
        if (File.Exists(chemin))
        {
            string json = File.ReadAllText(chemin);
            sauvegarde = JsonUtility.FromJson<SauvegardeJeu>(json);
        }
        else
        {
            sauvegarde = new SauvegardeJeu();
        }
    }


    public void MettreAJourNiveau(string nomScene, bool termine, bool pieces, float temps)
    {
        if (!sauvegarde.niveaux.ContainsKey(nomScene))
            sauvegarde.niveaux[nomScene] = new DonneesNiveau();

        var d = sauvegarde.niveaux[nomScene];
        d.niveauTermine = termine;
        d.toutesPiecesRecuperees = pieces;
        d.tempsUtilise = temps;

        Sauvegarder();
    }


    public DonneesNiveau GetNiveau(string nomScene)
    {
        if (sauvegarde.niveaux.ContainsKey(nomScene))
            return sauvegarde.niveaux[nomScene];
        return null;
    }
}
