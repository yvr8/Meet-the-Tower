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
            Debug.Log("Instance de SystemeSauvegarde initialis�e");
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
        Debug.Log("Sauvegarde effectu�e : " + json);
    }

    public void Charger()
    {
        if (File.Exists(chemin))
        {
            string json = File.ReadAllText(chemin);
            sauvegarde = JsonUtility.FromJson<SauvegardeJeu>(json);
            Debug.Log("Donn�es charg�es : " + json);  // Affiche les donn�es lues
        }
        else
        {
            sauvegarde = new SauvegardeJeu();
            Debug.Log("Aucune donn�e trouv�e, nouvelle sauvegarde cr��e.");
        }
    }


    public void MettreAJourNiveau(string nomScene, bool termine, bool pieces, float temps)
    {
        Debug.Log("Mise � jour des donn�es pour : " + nomScene);
        Debug.Log("Termin� : " + termine + ", Toutes les pi�ces : " + pieces + ", Temps : " + temps);

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
