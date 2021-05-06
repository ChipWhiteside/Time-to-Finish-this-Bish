using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{

    public static GameEvents instance;

    private void Awake()
    {
        instance = this;
    }

    public event Action onItemInteract;
    public void ItemInteract()
    {
        if (onItemInteract != null)
        {
            onItemInteract();
        }
    }

    /*public event Action<Item> onPickupItem;
    public void PickupItem(Item item)
    {
        if (onPickupItem != null)
        {
            onPickupItem(item);
        }
    }*/
}
