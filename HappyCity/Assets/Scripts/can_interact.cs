using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class can_interact : MonoBehaviour
{
    public bool isInteract { get; set; }
  
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isInteract = true;
        }
        else
        {
            isInteract = false;
        }
    }
}
