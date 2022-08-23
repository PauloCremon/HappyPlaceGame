using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    [SerializeField] private Transform playerPosition;
    void Update()
    {
        Vector3 newPosition = new Vector3(playerPosition.position.x, playerPosition.position.y,-10);
        transform.position = Vector3.Slerp(transform.position, newPosition, 2f*Time.deltaTime);
    }
}
