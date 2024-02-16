using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Inventory : ScriptableObject
{
    public Item currentItem;
    public List<Item> items = new List<Item>();
    public int numberOfKey;//Số đồ vật trong inventory
    public int coins;
    public void AddItem(Item itemToAdd)
    {
        //Is the item is key?
        if (itemToAdd.isKey)
        {
            numberOfKey++;
        }
        else
        {
            if (!items.Contains(itemToAdd)) //kiểm tra xem vật phẩm có chưa
            {
                items.Add(itemToAdd);
            }
        }
    }
 }
