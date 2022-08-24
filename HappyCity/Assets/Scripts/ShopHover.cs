using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopHover : MonoBehaviour
{
    private Animator ani;
    private void Start()
    {
        ani = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player") ani.SetBool("hide", true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")  ani.SetBool("hide", false);
    }
}
