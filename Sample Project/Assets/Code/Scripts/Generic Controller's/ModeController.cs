using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeController : MonoBehaviour
{
  public LevelManager[] LevelManagers;
  [HideInInspector]
  public LevelManager currentLevelManager;
  void Start()
  {
    currentLevelManager = LevelManagers[ApplicationController.SelectedGameMode];
    currentLevelManager.enabled = true;
  }
}
