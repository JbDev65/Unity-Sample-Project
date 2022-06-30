
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour
{
    #region Instance

    private static SettingsController _instance;

    public static SettingsController instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<SettingsController>();
            }

            return _instance;
        }
    }

    #endregion

    [SerializeField]
    private Scrollbar MasterSliderVol;

    [SerializeField]
    private Scrollbar MusicSliderVol;
    
    private MainMenuController _mainMenuController;

    private void Awake()
    {

        _instance = this;

    }


    private void Start()
    {
        _mainMenuController = MainMenuController.instance;
        
        MusicVolumeChanged(DataController.instance.musicVolume);
        SfxVolumeChanged(DataController.instance.sfxVolume);
    }

    private void SfxVolumeChanged(float newVolume)
    {
        if (MasterSliderVol != null)
        {
           
            MasterSliderVol.value = newVolume;
        }
    }

    private void MusicVolumeChanged(float newVolume)
    {
        if (MusicSliderVol != null)
        {
            
            MusicSliderVol.value = newVolume;
        }
    }
    
    public void MasterVol()
    {
        if (MasterSliderVol != null)
        {
            float VolValue = MasterSliderVol.value /1f;
            DataController.instance.sfxVolume = VolValue;
        }
    }

    public void MusicVol()
    {
        if (MusicSliderVol != null)
        {
            float VolValue = MusicSliderVol.value / 1f;
            DataController.instance.musicVolume = VolValue;
        }
    }
    
    public void Save()
    {
        _mainMenuController.RemoveLastPanelFormStack();
    }
}
