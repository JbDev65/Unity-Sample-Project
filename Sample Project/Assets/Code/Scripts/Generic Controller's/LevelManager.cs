using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public GameObject[] Levels;
    
    
    // Start is called before the first frame update
    void Start()
    {
        if(Levels.Length>0)
        Levels[ApplicationController.SelectedLevel].SetActive(true);
    }

 
}
