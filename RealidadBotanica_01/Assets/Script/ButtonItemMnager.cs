using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonItemMnager : MonoBehaviour
{
    private string itemName;
    private string itemDescription;
    private Sprite itemimage;
    private GameObject item3DModel;
    private ARInteractionManager interactionManager;

    public string ItemName
    {
        set { itemName = value; }
    }

    public string ItemDescription { set => itemDescription = value; } 

    public Sprite ItemImage { set => itemimage = value; }

    public GameObject Item3Dmodel { set => item3DModel = value; }



    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(0).GetComponent<TMP_Text>().text = itemName;
        transform.GetChild(1).GetComponent<RawImage>().texture = itemimage.texture;
        transform.GetChild(2).GetComponent<TMP_Text>().text = itemDescription;


        var button = GetComponent<Button>();
        button.onClick.AddListener(GameManager.instance.ARPosition);
        button.onClick.AddListener(Create3DModel);

        interactionManager = FindObjectOfType<ARInteractionManager>();
    }

    private void Create3DModel()
    {
       interactionManager.Item3DModel= Instantiate(item3DModel);
    }

}
