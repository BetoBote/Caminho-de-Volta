using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tranpulin : MonoBehaviour
{
    public Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
            {
                animator.SetTrigger("pulo");
            }
        
    }

   
}

