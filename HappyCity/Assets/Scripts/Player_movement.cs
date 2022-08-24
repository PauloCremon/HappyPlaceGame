using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player_movement : MonoBehaviour
{
    [SerializeField] private float movementVelocity = 1;
    [SerializeField] private GameObject mensageCanva;
    [SerializeField] private TextMeshProUGUI mensage;
    [SerializeField] private TextMeshProUGUI money;
    [SerializeField] private GameObject UI_Equip;

    [SerializeField] private GameObject[] itensCriados;
    [SerializeField] private GameObject[] corpo;

    static public int mooney = 157;
    private Rigidbody2D rig;
    private Animator ani;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();

    }

    void Update()
    {
        Move();
        money.text = "MONEY: " + mooney.ToString();
       
    }
    void Move()
    {
        Vector2 moveVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
       
        ani.SetFloat("velX", moveVector.x);
        ani.SetFloat("velY", moveVector.y);

        for(int i =0;i < itensCriados.Length; i++)
        {
            if (itensCriados[i] != null)
            {
                itensCriados[i].gameObject.GetComponent<Animator>().SetFloat("velX", moveVector.x);
                itensCriados[i].gameObject.GetComponent<Animator>().SetFloat("velY", moveVector.y);
            }
        }
        rig.velocity = moveVector * movementVelocity;
    }
     public  void ShowMensage(string mensageChange)
    {
        if(mensageChange != "")
        {
            mensageCanva.SetActive(true);
            mensage.text = mensageChange;
        }
        else mensageCanva.SetActive(false);

    }
    public void CreateItem(int i, GameObject itemPrefab,GameObject item2,GameObject item3)
    {
        if(item2==null && item3 == null)
        {
            itensCriados[i] = Instantiate(itemPrefab, corpo[i].transform.position, corpo[i].transform.rotation);
            itensCriados[i].transform.SetParent(corpo[i].transform);
        }
        else if(i==1)
        {
            itensCriados[i] = Instantiate(itemPrefab, corpo[i].transform.position, corpo[i].transform.rotation);
            itensCriados[i].transform.SetParent(corpo[i].transform);
            itensCriados[6] = Instantiate(item2, corpo[6].transform.position, corpo[6].transform.rotation);
            itensCriados[6].transform.SetParent(corpo[6].transform);
            itensCriados[7] = Instantiate(item3, corpo[7].transform.position, corpo[7].transform.rotation);
            itensCriados[7].transform.SetParent(corpo[7].transform);
        }
        else if (i == 2)
        {
            itensCriados[i] = Instantiate(itemPrefab, corpo[i].transform.position, corpo[i].transform.rotation);
            itensCriados[i].transform.SetParent(corpo[i].transform);
            itensCriados[3] = Instantiate(item2, corpo[3].transform.position, corpo[3].transform.rotation);
            itensCriados[3].transform.SetParent(corpo[3].transform);
            itensCriados[5] = Instantiate(item3, corpo[5].transform.position, corpo[5].transform.rotation);
            itensCriados[5].transform.SetParent(corpo[5].transform);
        }
        else if (i == 3)
        {
            itensCriados[8] = Instantiate(itemPrefab, corpo[8].transform.position, corpo[8].transform.rotation);
            itensCriados[8].transform.SetParent(corpo[8].transform);
            itensCriados[9] = Instantiate(item2, corpo[9].transform.position, corpo[9].transform.rotation);
            itensCriados[9].transform.SetParent(corpo[9].transform);
        }
    }
        
    
    public void CheckIfHasEquiped(int index)
    {
        if (index == 0 || index==4)
        {
            if (itensCriados[index] != null) Destroy(itensCriados[index].gameObject);
        }

        else if (index == 1)
        {
            if (itensCriados[index] != null)
            {
                Destroy(itensCriados[index].gameObject);
                Destroy(itensCriados[6].gameObject);
                Destroy(itensCriados[7].gameObject);
            }
        }
        else if (index == 2)
        {
            if (itensCriados[index] != null)
            {
                Destroy(itensCriados[index].gameObject);
                Destroy(itensCriados[3].gameObject);
                Destroy(itensCriados[5].gameObject);
            }
        }
        else if (index == 3)
        {
            if (itensCriados[8] != null && itensCriados[9] != null)
            {
                Destroy(itensCriados[8].gameObject);
                Destroy(itensCriados[9].gameObject);
            }
        }

    }
    public void ActiveEquip()
    {
        UI_Equip.SetActive(!UI_Equip.activeInHierarchy);

    }
}
