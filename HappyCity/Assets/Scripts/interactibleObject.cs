using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class interactibleObject : MonoBehaviour
{
    [SerializeField] private can_interact canInteract;
     private Player_movement pm;
    [SerializeField] UnityEvent interact;
    [SerializeField] string mensage;

    private bool canExecute = false;

    private void Start()
    {
        pm = FindObjectOfType<Player_movement>();
    }
    void Update()
    {
        if (canExecute)
        {
            if (canInteract.isInteract == true)
            {
                interact.Invoke();
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            canExecute = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            canExecute = false;
            pm.ShowMensage("");
           
        }
          
    }

    public void the_Interact()
    {
        pm.ShowMensage(mensage);
    }
    
}
