
using UnityEngine;

public class MenuController : MonoBehaviour
{

 #region Instance
 
 private static MenuController _instance;

 public static MenuController instance
 {
  get
  {
   if (_instance == null)
   {
    _instance = FindObjectOfType<MenuController>();
   }

   return _instance;
  }
 }
 
 #endregion

 private MainMenuController _mainMenuController;
 private InventoryController _inventoryController;
 private ModeSelectController _modeSelectController;

 private void Awake()
 {
  
  _instance = this;
  
 }


 private void Start()
 {
  _mainMenuController = MainMenuController.instance;
  _inventoryController = InventoryController.instance;
_modeSelectController = ModeSelectController.instance;
 }
 
 public void PlayBtnClick()
 {
   _mainMenuController.AddPanelToStackAndLoad(1);
   _modeSelectController.SelectedMode();
 }

 public void SettingBtnClick()
 {
  _mainMenuController.AddPanelToStackAndLoad(4);
 }
 public void InventoryBtnClick()
 {
  _inventoryController.Display();
 }
 public void ShopBtnClick()
 {
  _mainMenuController.AddPanelToStackAndLoad(6);
 }
 
 public void BackBtnClick()
 {
  _mainMenuController.AddPanelToStackAndLoad(5);
 }

 
}
