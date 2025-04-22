using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPiques : MonoBehaviour
{
    public float tempsActions;
    private PiqueStatique[] _listePique; 
    // Start is called before the first frame update
    void Start()    
    {
        _listePique = GetComponentsInChildren<PiqueStatique>();
        
        //InvokeRepeating();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
