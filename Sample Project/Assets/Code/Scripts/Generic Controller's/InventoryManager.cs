using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class InventoryManager : MonoBehaviour
{

    public Image TestImage;

    public Sprite[] Items;
    // Start is called before the first frame update
    void Start()
    {
        TestImage.sprite = Items[ApplicationController.SelectedInventoryItem];
    }

   
}
