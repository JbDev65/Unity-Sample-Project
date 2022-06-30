using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    #region Instance

    private static MainMenuController _instance;

    public static MainMenuController instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<MainMenuController>();
            }

            return _instance;
        }
    }

    #endregion

    public Canvas[] panels;
    public Stack<Canvas> panelsStack = new Stack<Canvas>();
    private int currentpanelIndex = -1;


    InventoryController _InventoryController;

    private void Awake()
    {
        _instance = this;
    }

    void Start()
    {
        _InventoryController = InventoryController.instance;
        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].enabled = false;
        }

        AddPanelToStackAndLoad(0);
    }

    public void AddPanelToStackAndLoad(int panelIndex)
    {
        if (panelsStack.Contains(panels[0]))
        {
            panelsStack.Peek().enabled = false;
        }

      
        panelsStack.Push(panels[panelIndex]);
        panelsStack.Peek().enabled = true;
        currentpanelIndex = panelIndex;
        
        peekInventoryPanel(true);

    }


    public void RemoveLastPanelFormStack()
    {
     
        peekInventoryPanel(false);
        
        panelsStack.Peek().enabled = false;
        panelsStack?.Pop();
        
        panelsStack.Peek().enabled = true;
        peekInventoryPanel(true);
        
    }


    public void peekInventoryPanel(bool _true)
    {
        if (_true)
        {
            if (panelsStack.Peek() == panels[3])
            {
                _InventoryController.ShowItem();

            }
            else
            {
                _InventoryController.HideItem();

            }
        }
        else
        {
            if (panelsStack.Peek() == panels[3])
            {
                _InventoryController.HideItem();
            }
        }

    }
}