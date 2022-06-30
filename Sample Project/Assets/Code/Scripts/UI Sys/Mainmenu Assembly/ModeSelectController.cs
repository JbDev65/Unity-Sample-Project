
using UnityEngine;
using UnityEngine.UI;

public class ModeSelectController : MonoBehaviour
{
    #region Instance
 
    private static ModeSelectController _instance;

    public static ModeSelectController instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<ModeSelectController>();
            }

            return _instance;
        }
    }
 
    #endregion

    private MainMenuController _mainMenuController;
    private LevelMenuController _levelMenuController;
    public Image[] ModeImages;
    private void Awake()
    {
  
        _instance = this;
  
    }


    private void Start()
    {
        _mainMenuController = MainMenuController.instance;
        _levelMenuController = LevelMenuController.instance;
    }
 
    public void PlayBtnClick()
    {
        _mainMenuController.AddPanelToStackAndLoad(2);
        _levelMenuController.ExecuteLevel();
        
    }
    
    public void ModeSelectOnBtnClick(int n)
    {
        ApplicationController.SelectedGameMode = n;
        // PlayBtnClick();
    }


    public void SelectedMode()
    {
        ModeImages[ApplicationController.SelectedGameMode].GetComponent<Selectable>().Select();
        
    }
}


