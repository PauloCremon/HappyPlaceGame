using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Shop : MonoBehaviour
{
    [SerializeField] private GameObject UI_Information;
    [SerializeField] private TextMeshProUGUI nameItem;
    [SerializeField] private TextMeshProUGUI description;
    [SerializeField] private TextMeshProUGUI price;

    [SerializeField] private GameObject[] ItensCreate;
    [SerializeField] private item[] item;
    
    public void OpenInformatio()
    {
        UI_Information.SetActive(!UI_Information.activeInHierarchy);
        
    }

    
}
