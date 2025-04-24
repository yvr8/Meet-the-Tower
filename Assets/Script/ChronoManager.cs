using UnityEngine;
using TMPro;

public class ChronoManager : MonoBehaviour
{
    public TMP_Text chronoText;
    private float timer = 0f;
    private bool isRunning = true;

    /// <summary>
    /// Lance le chronomètre au démarrage du script.
    /// </summary>
    void Start()
    {
        StartChrono();
    }

    
    /// <summary>
    /// Met à jour le temps écoulé à chaque frame si le chronomètre est actif, 
    /// et affiche le temps sous format MM:SS dans le texte associé.
    /// </summary>
    void Update()
    {
        if (isRunning)
        {
            timer += Time.deltaTime;
            int minutes = Mathf.FloorToInt(timer / 60f);
            int seconds = Mathf.FloorToInt(timer % 60f);
            chronoText.text = $"Time: {minutes:00}:{seconds:00}";
        }
    }

    /// <summary>
    /// Arrête le chronomètre.
    /// </summary>
    public void StopChrono()
    {
        isRunning = false;
    }

    /// <summary>
    /// Démarre ou redémarre le chronomètre.
    /// </summary>
    public void StartChrono()
    {
        isRunning = true;
    }

    /// <summary>
    /// Retourne le temps écoulé en secondes depuis le début du chronomètre.
    /// </summary>
    /// <returns>Temps écoulé en secondes.</returns>
    public float GetTime()
    {
        return timer;
    }
}
