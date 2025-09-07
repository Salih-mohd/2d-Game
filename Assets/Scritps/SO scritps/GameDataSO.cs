using UnityEngine;
using UnityEngine.Events;


[CreateAssetMenu(fileName = "GameData", menuName = "Game/GameData")]
public class GameDataSO : ScriptableObject
{
    // level progress

    public int unlockedLevel = 1;

    //Audio setting

    public float musicVolume=1f;
    public bool isMusicOn=true;


    private const string LevelKey = "UnlockedLevel";
    private const string VolumeKey = "MusicVolume";
    private const string MusicToggleKey = "MusicToggle";


    // events 

    public UnityEvent onGameVon;
    public UnityEvent onGameLose;

    public UnityEvent OnSeeingEnemy;
    public UnityEvent DyingEnemy;
    

    


    private void OnEnable()
    {
        //Load();
    }

    // saving to playerPref
    public void Save()
    {
        PlayerPrefs.SetInt(LevelKey, unlockedLevel);
        PlayerPrefs.SetFloat(VolumeKey, musicVolume);
        PlayerPrefs.SetInt(MusicToggleKey, isMusicOn ? 1 : 0);

        PlayerPrefs.Save();
    }

    // getting from player pref

    public void Load()
    {
        unlockedLevel = PlayerPrefs.GetInt(LevelKey, 1); 
        musicVolume = PlayerPrefs.GetFloat(VolumeKey, 1f); 
        isMusicOn = PlayerPrefs.GetInt(MusicToggleKey, 1) == 1;

        
    }

    public void SetVolume(float value)
    {
        musicVolume=value;
        Save();
    }

    public void SetMusicEnables(bool enabled)
    {
        isMusicOn=enabled;
        Save();
    }


    public void ResetProgress()
    {
        unlockedLevel = 1;
        Save();
    }
    

}
