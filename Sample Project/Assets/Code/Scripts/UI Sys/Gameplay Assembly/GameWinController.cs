
using UnityEngine;

public class GameWinController : MonoBehaviour
{
    #region Instance
 
    private static GameWinController _instance;

    public static GameWinController instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameWinController>();
            }

            return _instance;
        }
    }
 
    #endregion
 
    private void OnEnable()
    {
        GameController.gameEnded += endedClicked;
    }

    private void OnDisable()
    {
        GameController.gameEnded -= endedClicked;
    }
    
    private void Awake()
    {
        _instance = this;
  
    }
    
    public void endedClicked()
    {
        
    }
    public void display()
    {
        containerGO.enabled = true;
    }
 
    public void hide()
    {
        containerGO.enabled = false;

    }
 
    [Header("Panel Container")]
    public Canvas containerGO; 
}
