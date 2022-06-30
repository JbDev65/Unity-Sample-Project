using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
  
    #region Instance
 
    private static InventoryController _instance;

    public static InventoryController instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<InventoryController>();
            }

            return _instance;
        }
    }
 
    #endregion


    public InventoryItem[] InventoryItems;
     public Sprite[] Items;
    //public GameObject[] Items;
     public Image ItemSprite;
    public Button Buy;
    public TextMeshProUGUI PriceText;
    
    int i,tempSelectedItem;
    int inventoryItemButtonsLength;
    
    private MainMenuController _mainMenuController;
    private DataController _dataController;
    private LoadingController _loadingController;

    private void Awake()
    {
        _instance = this;
    }


    private void Start()
    {
        _mainMenuController = MainMenuController.instance;
        _dataController = DataController.instance;
        _loadingController = LoadingController.instance;
    }
 
   
    public void UnlockingInventoryItem()
    {
        inventoryItemButtonsLength = InventoryItems.Length;

        if (inventoryItemButtonsLength <= 0) return;

        for (i = 0; i < inventoryItemButtonsLength; i++)
        {
            if (_dataController.GetUnlockInventoryItem(i))
            {
                InventoryItems[i].inventoryItemlockButtons.SetActive(false);
            }
            else
            {
                InventoryItems[i].inventoryItemlockButtons.SetActive(true);
            }
        }
    }

    int j,itemsLength;
    
    public void SelectInventoryItem(int i)
    {
        itemsLength = Items.Length;
        
    //    --------------- For 3D Items -----------------
//    
//        for (j = 0; j < itemsLength; j++)
//        {
//            Items[j].SetActive(false);
//        }
//        Items[tempSelectedItem].SetActive(true);
//        


        tempSelectedItem = i;
        
        //    --------------- For 2D Items -----------------
         ItemSprite.sprite= Items[tempSelectedItem]; 
         //    --------------- --- -----------------
         
        for (i = 0; i < inventoryItemButtonsLength; i++)
        {
            InventoryItems[i].selectedImage.SetActive(false);
        }

         InventoryItems[tempSelectedItem].selectedImage.SetActive(true);
         
        if (_dataController.GetUnlockInventoryItem(tempSelectedItem))
        {
            ApplicationController.SelectedInventoryItem = tempSelectedItem;
            Buy.gameObject.SetActive(false);
        }
        else
        {
            Buy.gameObject.SetActive(true);
            PriceText.text=InventoryItems[tempSelectedItem].price.ToString();
        }
        
    }

    public void cancelInventoryItem()
    {
        SelectInventoryItem(ApplicationController.SelectedInventoryItem);
        
    }

    public void HideItem()
    {
        //    --------------- For 3D Items -----------------
        //    Items[tempSelectedItem].SetActive(false);
        //    Items[ApplicationController.SelectedInventoryItem].SetActive(false);
    }
    public void ShowItem()
    {
        //    --------------- For 3D Items -----------------
       // Items[tempSelectedItem].SetActive(true);
    }


    public void UnlockInventoryItem()
    {
        _dataController.SetUnlockInventoryItem(tempSelectedItem);
        _dataController.RemoveCoins(InventoryItems[tempSelectedItem].price);
        print(InventoryItems[tempSelectedItem].price);
        InventoryItems[tempSelectedItem].inventoryItemlockButtons.SetActive(false);
        ApplicationController.SelectedInventoryItem = tempSelectedItem;

        
    }

    public void BuyInventoryItem()
    {
        if (_dataController.coins >= InventoryItems[tempSelectedItem].price)
        {
            UnlockInventoryItem();
            Buy.gameObject.SetActive(false);

        }
        else
        {
           
            _mainMenuController.AddPanelToStackAndLoad(8);
        }
    }
  

    public void Display()
    {
        UnlockingInventoryItem();
        SelectInventoryItem(ApplicationController.SelectedInventoryItem);
        _mainMenuController.AddPanelToStackAndLoad(3);
    }


   

    public void Play()
    {
        HideItem();
        _loadingController.display(Scenes.Gameplay);
    }
}

[Serializable]
public class InventoryItem
{
    public GameObject selectedImage;
    public GameObject inventoryItemlockButtons;
    public int price;
}