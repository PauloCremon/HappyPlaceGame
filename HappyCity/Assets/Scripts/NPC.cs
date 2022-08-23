using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEditor.UI;
using TMPro;

public class NPC : MonoBehaviour
{
    [SerializeField] private can_interact canInteract;
    [SerializeField] UnityEvent interact;
    [SerializeField] private GameObject DialogPanel;
    [SerializeField] private TextMeshProUGUI dialogText;
    [SerializeField] private string[] dialog;
    [SerializeField] private GameObject button;
    [SerializeField] private GameObject buy;
    [SerializeField] private GameObject sell;
    [SerializeField] private GameObject Shop;
    [SerializeField] private GameObject btSellPl;

    private Animator ani;
    private int index;
    private float wordSpeed;
    private bool canExecute = false;

    private void Awake()
    {
        ani = GetComponent<Animator>();
        btSellPl.SetActive(false);
        Shop.SetActive(false);
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
        if(dialogText.text == dialog[index])
        {
            button.SetActive(true);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            ani.SetTrigger("rise");
            canExecute = true;
            btSellPl.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canExecute = false;
            btSellPl.SetActive(false);
            Shop.SetActive(false);
        }
    }

    public void SetDialog()
    {
        if (DialogPanel.activeInHierarchy)
        {
            zeroText();
        }
        else
        {
            DialogPanel.SetActive(true);
            buy.SetActive(false);
            sell.SetActive(false);
            StartCoroutine(Typing());
        }
    }

    private void zeroText()
    {
        
        dialogText.text = "";
        index = 0;
        DialogPanel.SetActive(false);
    }

    IEnumerator Typing()
    {
        foreach(char letter in dialog[index].ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine()
    {
        button.SetActive(false);
        buy.SetActive(false);
        sell.SetActive(false);
        if (index < dialog.Length - 1)
        {
            index++;
            dialogText.text = "";
            StartCoroutine(Typing());
        }
        else if(index == dialog.Length - 1){
            dialogText.text = "";
            buy.SetActive(true);
            sell.SetActive(true);
        }
        else zeroText();
    }

    public void OpenShop()
    {
        Shop.SetActive(!Shop.activeInHierarchy);
        zeroText();
    }
    public void OpenEquip()
    {
        btSellPl.SetActive(true);
        zeroText();
    }
}
