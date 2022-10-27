using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    bool hasPackage = false;

    [SerializeField]
    private float destroyDelay = 0.2f;
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Ouch!");
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if ( other.tag == "Package" && !hasPackage )
        {
            Debug.Log("Package picked up");
            hasPackage = true;
            Destroy(other.gameObject, destroyDelay);
        }

        if ( other.tag == "Customer" && hasPackage )
        {
            Debug.Log("Package delivered");
            hasPackage = false;
        }
    }
}
