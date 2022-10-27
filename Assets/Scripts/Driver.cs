using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField]
    [Range(0, 100)]
    [Tooltip("Vehicle movement speed in m/s")]
    private int movementSpeed = 20;
    [SerializeField]
    [Range(0, 180)]
    [Tooltip("Vehicle steering speed in °/s")]
    private int steeringSpeed = 70;


    void Start()
    {

    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.Rotate(Vector3.back * steeringSpeed * Time.deltaTime * horizontalInput);
        transform.Translate(Vector3.up * movementSpeed * Time.deltaTime * verticalInput);
    }
}
