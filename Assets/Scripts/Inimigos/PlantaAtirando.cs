using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantaAtirando : MonoBehaviour
{
    public Rigidbody2D Tiro;
    public float velocityTiro;
    public Transform posDown;
    
    public Transform posLeft;

    public float timeThrowTiro;
    private void Start()
    {
        InvokeRepeating("AtirarTiro", 0, timeThrowTiro);
    }

    public void AtirarTiro()
    {
        StartCoroutine(DispararTiro());
    }

    IEnumerator DispararTiro()
    {
        yield return new WaitForSeconds(1f);

        Rigidbody2D clone;
        clone = Instantiate(Tiro, posDown.transform.position, posLeft.transform.rotation);
        clone.velocity = transform.TransformDirection(Vector2.down * velocityTiro);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
