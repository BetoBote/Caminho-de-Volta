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
        clone.velocity = transform.TransformDirection(Vector2.down * 6);
        Rigidbody2D clone2;
        clone2 = Instantiate(Tiro, posDown.transform.position, posLeft.transform.rotation);
        clone2.velocity = transform.TransformDirection(Vector2.down * velocityTiro + Vector2.right * 3);
        Rigidbody2D clone3;
        clone3 = Instantiate(Tiro, posDown.transform.position, posLeft.transform.rotation);
        clone3.velocity = transform.TransformDirection(Vector2.down * velocityTiro + Vector2.right * -1 * 3);

        Destroy(clone.gameObject, 2f);
        Destroy(clone2.gameObject, 2f);
        Destroy(clone3.gameObject, 2f);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
