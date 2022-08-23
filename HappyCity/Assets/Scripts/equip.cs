using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class equip : MonoBehaviour
{
    [SerializeField] private GameObject UI_Equip;
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private TextMeshProUGUI itemDescription;
    [SerializeField] private TextMeshProUGUI itemSell;

    [SerializeField] private bool[] isFull;
    [SerializeField] private GameObject[] icon;
    [SerializeField] private item[] item;


    [SerializeField] private Player_movement pm;
    private int ItemActive;
    
    void Update()
    {
        refreshItem();
        
    }
    private void refreshItem()
    {
        if (UI_Equip.activeInHierarchy)
        {

            for (int i = 0; i < item.Length; i++)
            {
                if (item[i] != null)
                {
                    icon[i].SetActive(true);
                    isFull[i] = true;
                    icon[i].gameObject.GetComponent<Image>().sprite = item[i].icon;
                }
                else
                {
                    icon[i].SetActive(false);
                    isFull[i] = false;
                    pm.CheckIfHasEquiped(i);
                }
            }
        }
    }
    public void clearInformation()
    {
        itemName.text = "";
        itemDescription.text = "";
        itemSell.text = "";
    }
    public void showInformationHead()
    {
        ItemActive = 0;
        itemName.text = item[0].name;
        itemDescription.text = item[0].description;
        itemSell.text = item[0].price_sell.ToString();
    }
    public void showInformationTorso()
    {
        ItemActive = 1;
        itemName.text = item[1].name;
        itemDescription.text = item[1].description;
        itemSell.text = item[1].price_sell.ToString();
    }
    public void showInformationLegs()
    {
        ItemActive = 2;
        itemName.text = item[2].name;
        itemDescription.text = item[2].description;
        itemSell.text = item[2].price_sell.ToString();
    }
    public void showInformationShoes()
    {
        ItemActive = 3;
        itemName.text = item[3].name;
        itemDescription.text = item[3].description;
        itemSell.text = item[3].price_sell.ToString();
    }
    public void showInformationAcessory()
    {
        ItemActive = 4;
        itemName.text = item[4].name;
        itemDescription.text = item[4].description;
        itemSell.text = item[4].price_sell.ToString();
    }
    public void momentEquip(int index, item itemRec)
    {
        item[index] = itemRec;
        refreshItem();
    }
    public void sellItem()
    {
        Player_movement.mooney += item[ItemActive].price_sell;
            item[ItemActive] = null;
        refreshItem();
    }
  
}
