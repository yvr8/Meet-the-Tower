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
            Debug.Log("Instance de SystemeSauvegarde initialisée");
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
        Debug.Log("Sauvegarde effectuée : " + json);
    }

    public void Charger()
    {
        if (File.Exists(chemin))
        {
            string json = File.ReadAllText(chemin);
            sauvegarde = JsonUtility.FromJson<SauvegardeJeu>(json);
            Debug.Log("Données chargées : " + json);  // Affiche les données lues
        }
        else
        {
            sauvegarde = new SauvegardeJeu();
            Debug.Log("Aucune donnée trouvée, nouvelle sauvegarde créée.");
        }
    }


    public void MettreAJourNiveau(string nomScene, bool termine, bool pieces, float temps)
    {
        Debug.Log("Mise à jour des données pour : " + nomScene);
        Debug.Log("Terminé : " + termine + ", Toutes les pièces : " + pieces + ", Temps : " + temps);

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
