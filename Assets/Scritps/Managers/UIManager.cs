using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{

    [SerializeField] private GameDataSO gameData;

    [Header("UI References")]
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Toggle musicToggle;
    [SerializeField] private GameObject WinImage;
    [SerializeField] private GameObject LoseImage;
    [SerializeField] private InputActionAsset inputActions;

    

    [SerializeField] private GameObject settingsPanel;

    [SerializeField] private InputReader inputReader;

    [SerializeField] private Slider healthBarSlider;

    [SerializeField] private Slider enemyHealthBar;




    private void Start()
    {
        Canvas.ForceUpdateCanvases();

        //gameData.ResetProgress();
        //gameData.Load();

        volumeSlider.value=gameData.musicVolume;
        musicToggle.isOn=gameData.isMusicOn;

        //add listneres
        volumeSlider.onValueChanged.AddListener(OnVolumeChanged);
        musicToggle.onValueChanged.AddListener(OnMusicToggleChanged);
        
    }

    private void OnEnable()
    {
        gameData.onGameVon.AddListener(ShowWinImage);
        gameData.onGameLose.AddListener(ShowLoseImage);
    }

    private void OnDisable()
    {
        gameData.onGameVon.RemoveListener(ShowWinImage);
        gameData.onGameLose.RemoveListener(ShowLoseImage);
    }


    
    private void OnVolumeChanged(float value)
    {
        gameData.SetVolume(value);
        AudioManager.Instance.SettingVolume(value);
    }

    private void OnMusicToggleChanged(bool isOn)
    {
        gameData.SetMusicEnables(isOn);
        AudioManager.Instance.settingMute(isOn);
       
    }


    // for main menu
    public void SelectLevel(int level)
    {
        SceneManager.LoadSceneAsync(level);
    }

    public void QuitGame()
    {
        gameData.Save();

        Invoke("ExitGame", 2);
        
    }

    private void ExitGame()
    {
        Application.Quit();
    }

    // canvas group managing

    public void ShowButton(CanvasGroup obj)
    {
        if (!obj) return;
        obj.alpha = 1f;
        obj.interactable = true;
        obj.blocksRaycasts = true;
    }

    public void HideButton(CanvasGroup obj)
    {
        if (!obj) return;
        obj.alpha = 0f;
        obj.interactable = false;
        obj.blocksRaycasts = false;
    }

    // end ****************


    public void HideGameObjects(GameObject obj)
    {
        obj.SetActive(false);
    }

    public void ShowGameObjects(GameObject obj)
    {
        obj.SetActive(true);
    }
    



    // win and lose panels
    

    public void ShowLoseImage()
    {

        inputActions.FindActionMap("Player").Disable();
        StartCoroutine("LosePanelCoroutine");

    }

    IEnumerator LosePanelCoroutine()
    {
        yield return new WaitForSeconds(3);
        LoseImage.SetActive(true);

    }


    public void ShowWinImage()
    {
        inputActions.FindActionMap("Player").Disable();
        StartCoroutine("WinPanelCoroutine");
        healthBarSlider.enabled = false;


    }


    IEnumerator WinPanelCoroutine()
    {
        yield return new WaitForSeconds(3);

        WinImage.SetActive(true);

    }

    // end *********************


    // pause menu

    public void ShowPauseMenu()
    {
        settingsPanel.SetActive(true);
        inputActions.FindActionMap("Player").Disable();
    }

    public void ClosePauseMenu()
    {
        inputActions.FindActionMap("Player").Enable();
    }
    

    // managing health;

    public void DecreaseHealth(int value)
    {
        if (healthBarSlider.value > 2)
        {
            healthBarSlider.value -= value;
        }
        else
        {
            healthBarSlider.value -= value;
            GameManger.Instance.GameLoseInvoke();
        }
        
    }


    // managing enemy health

    public void DecreaseEnemyHealth(int value)
    {
       

        if (enemyHealthBar.value > 2)
        {
            enemyHealthBar.value -= value;
        }
        else
        {
            enemyHealthBar.value -= value;
            gameData.DyingEnemy.Invoke();
        }

    }





}
