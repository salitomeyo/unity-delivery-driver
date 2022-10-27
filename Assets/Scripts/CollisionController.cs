using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    bool hasPackage = false;

    [SerializeField] private float destroyDelay = 0.2f;
    [SerializeField] private Color32 packageColor = new Color32 (1,1,1,1); 
    [SerializeField] private Color32 originalColor = new Color32 (1,1,1,1);


    SpriteRenderer spriteRenderer;

    void Start() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

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
            spriteRenderer.color = packageColor;
        }

        if ( other.tag == "Customer" && hasPackage )
        {
            Debug.Log("Package delivered");
            hasPackage = false;
            spriteRenderer.color = originalColor;
        }
    }
}
