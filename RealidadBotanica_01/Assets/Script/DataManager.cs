using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [SerializeField] private List<Item> items = new List<Item>();
    [SerializeField] private GameObject buttonContainer;
    [SerializeField] private ButtonItemMnager itemButtonManager;

    private void Start()
    {
        GameManager.instance.OnitemsMenu += CreateButtons; 
    }

    private void CreateButtons()
    {
        foreach (var item in items)
        {
            ButtonItemMnager buttonItem;
            buttonItem = Instantiate(itemButtonManager, buttonContainer.transform);
            buttonItem.ItemName = item.ItemName;
            buttonItem.ItemDescription = item.ItemDescription;
            buttonItem.ItemImage = item.ItemImage;
            buttonItem.Item3Dmodel = item.Item3DModel;
            buttonItem.name = item.ItemName;

        }

        GameManager.instance.OnitemsMenu -= CreateButtons;
    }
}
