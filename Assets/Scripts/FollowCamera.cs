using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField]
    [Tooltip("The object the camera must follow")]
    private GameObject player;

    void LateUpdate()
    {
        transform.position = player.transform.position + new Vector3(0, 0, -15);
    }
}
