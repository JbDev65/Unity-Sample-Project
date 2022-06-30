
using System.Collections;
using UnityEngine;

public class LoadingController : MonoBehaviour
{
    #region Instance
 
    private static LoadingController _instance;

    public static LoadingController instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<LoadingController>();
            }

            return _instance;
        }
    }
 
    #endregion
    
    [Header("Panel Container")]
    public Canvas containerGO;

    public int TimeToLoad;
    
    private SceneMngmtController _sceneMngmtController;
 
    private void Awake()
    {
        _instance = this;

    }

    public void Start()
    {
    _sceneMngmtController=SceneMngmtController.instance;
        
    }

    public void PrintIndexes()
    {
        print(ApplicationController.SelectedLevel);
        print(ApplicationController.SelectedGameMode);
        print(ApplicationController.SelectedInventoryItem);
    }

    public void display(Scenes s)
    {
        containerGO.enabled = true;
        StartCoroutine(LoadScene(s));
    }

    public IEnumerator LoadScene(Scenes s)
    {
        yield return new WaitForSeconds(TimeToLoad);
        _sceneMngmtController.LoadScene(s);
    }

    public void hide()
    {
        containerGO.enabled = false;

    }
 
 

}
