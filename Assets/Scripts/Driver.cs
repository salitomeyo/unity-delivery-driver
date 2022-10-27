using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] [Range(0, 100)] [Tooltip("Vehicle movement speed in m/s")] private int movementSpeed = 20;
    [SerializeField] [Range(0, 180)] [Tooltip("Vehicle steering speed in °/s")] private int steeringSpeed = 70;
    [SerializeField] private int calculatedSpeed = 20;
    [SerializeField] private int slowSpeed = 15;
    [SerializeField] private int boostSpeed = 25;


    void Start()
    {
        calculatedSpeed = movementSpeed;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.Rotate(Vector3.back * steeringSpeed * Time.deltaTime * horizontalInput);
        transform.Translate(Vector3.up * calculatedSpeed * Time.deltaTime * verticalInput);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Bump")
        {
            calculatedSpeed = slowSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Boost")
        {
            Debug.Log("You are boosting");
            calculatedSpeed = boostSpeed;
        }
    }
}
