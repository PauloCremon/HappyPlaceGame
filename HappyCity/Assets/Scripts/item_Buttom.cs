using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class item_Buttom : MonoBehaviour
{
    [SerializeField] private GameObject UI_Information;
    [SerializeField] private TextMeshProUGUI nameItem;
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private TextMeshProUGUI price;

    [SerializeField] private GameObject[] ItensCreate;
    [SerializeField] private item item;

    [SerializeField] private int numItem;
    [SerializeField]private Player_movement pm;
    [SerializeField] private equip eq;
    private Image sprite;
    private void Start()
    {
        sprite = transform.Find("icon").GetComponent<Image>();
        sprite.sprite = item.icon;
    }

    public void OpenInformatio()
    {
        UI_Information.SetActive(true);
        nameItem.text = item.name;
        description.text = item.description;
        price.text = item.price_buy.ToString();
        

    }
    public void CloseInformatio()
    {
        UI_Information.SetActive(false);
        nameItem.text = "";
        description.text = "";
        price.text = "";


    }
    public void buy()
    {
        if(ItensCreate!=null && Player_movement.mooney >= item.price_buy)
        {
            Player_movement.mooney -= item.price_buy;
            if(ItensCreate.Length==1)
                pm.CreateItem(numItem, ItensCreate[0],null,null);
            else if(ItensCreate.Length ==2){
                pm.CreateItem(numItem, ItensCreate[0], ItensCreate[1], null);
            }
            else if (ItensCreate.Length == 3)
            {
                pm.CreateItem(numItem, ItensCreate[0], ItensCreate[1], ItensCreate[2]);
            }

            eq.momentEquip(numItem,item);

        }
        
    }
}
