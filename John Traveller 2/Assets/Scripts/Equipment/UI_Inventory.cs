﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : MonoBehaviour
{
    private Inventory inventory;
    private Transform itemSlotContainer;
    private Transform itemSlotTemplate;

    private void Awake()
    {
        itemSlotContainer = transform.Find("itemSlotContainer");
        itemSlotTemplate = itemSlotContainer.Find("itemSlotTemplate");
    }
    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;
        RefreshInventoryItems();
    }

    private void RefreshInventoryItems()
    {
        foreach (Item item in inventory.GetItemList())
        {
            int x = 0;
            int y = 0;
            float itemSlotCellSize = 30f;
           RectTransform itemSlotReactTransfrom = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
           itemSlotReactTransfrom.gameObject.SetActive(true);
           itemSlotReactTransfrom.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
           Image image = itemSlotReactTransfrom.Find("image").GetComponent<Image>();
           image.sprite = item.GetSprite();
           x++;
           if (x > 4)
           {
               x = 0;
               y++;
           }
               
        }
    }
}