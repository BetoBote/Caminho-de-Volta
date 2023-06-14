using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FundoSegue : MonoBehaviour
{
    public GameObject personagem;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float posX = personagem.transform.position.x * 0.8f;
        transform.position = new Vector3(posX, transform.position.y, transform.position.z);
    }
}
