
using TMPro;
using UnityEngine;

public class InGameController : MonoBehaviour
{
    #region Instance
 
    private static InGameController _instance;

    public static InGameController instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<InGameController>();
            }

            return _instance;
        }
    }
 
    #endregion

    public TextMeshProUGUI LevelText;

    public void Start()
    {
        LevelText.text = ScriptLocalization.LevelTitle + (ApplicationController.SelectedLevel+1).ToString();
    }

    private void OnEnable()
    {
        GameController.gamePaused += pauseClicked;
        GameController.gameResumed += resumeClicked;
        GameController.gameStarted += startedClicked;
        GameController.gameEnded += endedClicked;
    }

    private void OnDisable()
    {
        
        GameController.gamePaused -= pauseClicked;
        GameController.gameResumed -= resumeClicked;
        GameController.gameStarted -= startedClicked;
        GameController.gameEnded -= endedClicked;
    }
    
    private void Awake()
    {
        _instance = this;
  
    }
    
    public void pauseClicked()
    {
        
    }
    public void resumeClicked()
    {
        
    }
    public void startedClicked()
    {
        
    }
    public void endedClicked()
    {
        
    }
}
