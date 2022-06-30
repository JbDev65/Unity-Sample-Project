
using UnityEngine;

public class ExitController : MonoBehaviour
{
    #region Instance
 
    private static ExitController _instance;

    public static ExitController instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<ExitController>();
            }

            return _instance;
        }
    }
 
    #endregion
 
    private MainMenuController _mainMenuController;
    
    private void Awake()
    {
  
        _instance = this;
  
    }


    private void Start()
    {
        _mainMenuController = MainMenuController.instance;
    }
    
    public void Yes()
    {
       Application.Quit();
        
    }
 
    public void No()
    {
        _mainMenuController.RemoveLastPanelFormStack();
    }
 
  
}
