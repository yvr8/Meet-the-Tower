using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GestionPause : MonoBehaviour
{
    private PlayerInputReader _inputReader;
    // Start is called before the first frame update
    void Start()
    {
        _inputReader.Menu.callback += Pause;
    }

    void Pause()
    {
        Debug.Log("Pause");
    }
}
