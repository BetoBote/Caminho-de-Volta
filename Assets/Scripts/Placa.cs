using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]

public class Placa : MonoBehaviour
{

    public GameObject canvasPlaca;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        canvasPlaca.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canvasPlaca.SetActive(false);
    }
}
