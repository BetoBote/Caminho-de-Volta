using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LigaDesligaController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AtivarGO() 
    {
        gameObject.SetActive(true);
    }

    public void DesativarGO() 
    {
        gameObject.SetActive(false);
    }

}
