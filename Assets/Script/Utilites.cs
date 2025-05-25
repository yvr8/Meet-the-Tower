using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Utilites
{
    public static float remapper(float valeur, float echelle1Min, float echelle1Max, float echelle2Min, float echelle2Max) 
    {
        // Empêche la valeur d'être en dehors de l'échelle 1
        if (valeur < echelle1Min)
            valeur = echelle1Min;
        else if (valeur > echelle1Max)
            valeur = echelle1Max;

        return (valeur - echelle1Min) / (echelle1Max - echelle1Min) * (echelle2Max - echelle2Min) + echelle2Min;
    }
}
