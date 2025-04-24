using UnityEngine;
using TMPro;

public class ChronoManager : MonoBehaviour
{
    public TMP_Text chronoText;
    private float timer = 0f;
    private bool isRunning = true;

    void Start()
    {
        StartChrono();
    }

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

    public void StopChrono()
    {
        isRunning = false;
    }

    public void StartChrono()
    {
        isRunning = true;
    }

    public float GetTime()
    {
        return timer;
    }
}
