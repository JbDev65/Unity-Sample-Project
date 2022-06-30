
using UnityEngine;

public class GameOverController : MonoBehaviour
{  
    #region Instance
 
    private static GameOverController _instance;

    public static GameOverController instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameOverController>();
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
