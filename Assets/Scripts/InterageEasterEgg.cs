using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterageEasterEgg : MonoBehaviour
{
    public bool EstaInteragindo { get; set; }

    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetButtonDown("Interage"))
        {
            EstaInteragindo = true;
        }
        else
        {
            EstaInteragindo = false;
        }
    }
}
