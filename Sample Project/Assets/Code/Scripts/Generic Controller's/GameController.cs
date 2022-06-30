
using UnityEngine;

public class GameController : MonoBehaviour
{
    #region Instance
 
    private static GameController _instance;

    public static GameController instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameController>();
            }

            return _instance;
        }
    }
 
    #endregion
     
    private GameOverController _gameOverController;

    private GameWinController _gameWinController;

    private ModeController _modeController;

    private LoadingController _loadingController;

    public delegate void GameStatusHandler();

    public static event GameStatusHandler gamePaused;

    public static event GameStatusHandler gameResumed;

    public static event GameStatusHandler gameStarted;

    public static event GameStatusHandler gameEnded;

    public static event GameStatusHandler gameRestarted;

    public delegate void Cinematic();

    public static event Cinematic cinematicEvent;

    public static GameStatus _gameStatus = GameStatus.INGAME;
    
    public static GameStatus gameStatus
    {
        get
        {
            return _gameStatus;
        }
        set
        {
            _gameStatus = value;
        }
    }
    
    private void Awake()
    {
        _instance = this;
  
    }
    
   

    void Start()
    {
        _gameOverController=GameOverController.instance;
        _gameWinController=GameWinController.instance;
        _loadingController=LoadingController.instance;
        GameStart();

    }
    

    public void displayGameOver()
    {
        gameStatus = GameStatus.GAMEOVER;
        _gameOverController.display();
        gameEnded?.Invoke();
    }

    public void displayGameWin()
    {
        gameStatus = GameStatus.GAMEOVER;
        _gameWinController.display();
        gameEnded?.Invoke();
        DataController.instance.SetUnlockLevel(ApplicationController.SelectedLevel);
    }

    
    public void GameStart()
    {
        gameStatus = GameStatus.INGAME;
		
        if (gameStatus == GameStatus.PAUSED)
        {
            gameResumed?.Invoke();

        }
        else
        {
            gameStarted?.Invoke();
        }
    }

    public void GameResumed()
    {
        if (gameStatus == GameStatus.PAUSED)
        {
            gameStatus = GameStatus.INGAME;
            gameResumed?.Invoke();
        }
        
    }
    
    public void GamePaused()
    {
        gameStatus = GameStatus.PAUSED;
        gamePaused?.Invoke();
    }

    public  void GameRestart()
    {
        gameRestarted?.Invoke();
        _loadingController.display(Scenes.Gameplay);
    }

    public void Home()
    {
        _loadingController.display(Scenes.Mainmenu);

    }

    public void Next()
    {
        if (ApplicationController.SelectedLevel >= _modeController.currentLevelManager.Levels.Length)
        {
            ApplicationController.SelectedLevel = 0;
        }
        else
        {
            ApplicationController.SelectedLevel += 1;
            ApplicationController.LastSelectedLevel = ApplicationController.SelectedLevel;
        }
        _loadingController.display(Scenes.Gameplay);
        
    }
}

