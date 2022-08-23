using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class item : ScriptableObject
{
    public new string name;
    public string description;

    public Sprite icon;

    public int code;

    public int price_buy;
    public int price_sell;
    
}
