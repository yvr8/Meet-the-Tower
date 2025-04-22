using System;
using System.Collections.Generic;

[Serializable]
public class DonneesNiveau
{
    public bool niveauTermine;
    public bool toutesPiecesRecuperees;
    public float tempsUtilise;
}

[Serializable]
public class SauvegardeJeu
{
    public Dictionary<string, DonneesNiveau> niveaux = new Dictionary<string, DonneesNiveau>();
}