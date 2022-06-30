
using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelMenuController : MonoBehaviour
{
    #region Instance

    private static LevelMenuController _instance;

    public static LevelMenuController instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<LevelMenuController>();
            }

            return _instance;
        }
    }

    #endregion

    public Button[] levelButtons;
    public GameObject[] lockButtons;
    //public Scrollbar _levelSlider;
    public int customMode,customLevelUnlock;
    int i,lastSelectedLevel;
    int levelButtonsLength;
    
    private DataController _dataController;
    private InventoryController _inventoryController;

    private void Awake()
    {
        _instance = this;

    }

    private void Start()
    {
        _inventoryController = InventoryController.instance;
        _dataController = DataController.instance;
    }

    public void ExecuteLevel()
    {
        UnlockingLevel();
    }

    public void OnClickSelectLevel(int index)
    {
        ApplicationController.SelectedLevel = index;
        _inventoryController.Display();

    }

    public void Play()
    {
        OnClickSelectLevel(ApplicationController.SelectedLevel);
        
    }

    public void UnlockingLevel()
    {
        levelButtonsLength = levelButtons.Length;

        if (levelButtons.Length <= 0) return;

        for (i = 0; i < levelButtonsLength; i++)
        {
            if (_dataController.GetUnlockLevel(i))
            {
                levelButtons[i].interactable = true;
                lockButtons[i].SetActive(false);
               
                lastSelectedLevel = i;
            }
            else
            {
                levelButtons[i].interactable = false;
                lockButtons[i].SetActive(true);

            }
        }
        
        SpriteState state = new SpriteState();
        

        ApplicationController.LastSelectedLevel = lastSelectedLevel;
        ApplicationController.SelectedLevel = ApplicationController.LastSelectedLevel;
      
        levelButtons[ApplicationController.LastSelectedLevel].GetComponent<Selectable>().Select();
       // setSlider();
    }

    // public float tempSlidervalue;
    // public void setSlider()
    // {
    //
    //     tempSlidervalue=(lastSelectedLevel) / 10f;
    //     _levelSlider.value = tempSlidervalue;
    // }

    #region LevelSelectionAnimation

    /// <summary>
    /// Custom Script for animating Level Selection Background and Level Buttons
    /// </summary>

    public Animator LevelSelectionBGAnimator;
    public Animator ScrollBarAnimator;
    public Animator LevelSelectionPlayAnimator;

    [ContextMenu("AnimateMe")]
    public void AnimateLevelSelection()
    {
        StartCoroutine(AnimatewithDelay());
        ScrollBarAnimator.gameObject.SetActive(false);
        LevelSelectionPlayAnimator.gameObject.SetActive(false);

    }

    IEnumerator AnimatewithDelay()
    {
        LevelSelectionBGAnimator.enabled = true;
        LevelSelectionBGAnimator.Play(0);
        yield return new WaitForSecondsRealtime(3.5f);
        ScrollBarAnimator.gameObject.SetActive(true);
        LevelSelectionPlayAnimator.gameObject.SetActive(true);
        ScrollBarAnimator.enabled = true;
        LevelSelectionPlayAnimator.enabled = true;
        ScrollBarAnimator.Play(0);
        LevelSelectionPlayAnimator.Play(0);
    }


    #endregion

    [ContextMenu("Unlock Level")]
    public void CustomLevelUnlocking()
    {
        ApplicationController.SelectedGameMode = customMode;

        for (int j = 0; j < customLevelUnlock; j++)
        {
            DataController.instance.SetUnlockLevel(j);
        }
    }
}
