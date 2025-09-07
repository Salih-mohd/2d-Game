using System.Net.NetworkInformation;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public static AudioManager Instance;

    [SerializeField] private GameDataSO gameDataSO;

    [SerializeField] private AudioSource bgMusic;
    [SerializeField] private AudioSource jumpFX;
    [SerializeField] private AudioSource dieFX;
    [SerializeField] private AudioSource runFX;
    [SerializeField] private AudioSource winFX;
    [SerializeField] private AudioSource attackFX;
    [SerializeField] private AudioSource explosionSFX;
    [SerializeField] private AudioSource nearEnemySfx;

    [SerializeField] private AudioListener audioListener;





    

    private void Awake()
    {
        Instance = this;
        //bgMusic.volume=gameDataSO.musicVolume;
        bgMusic.mute = gameDataSO.isMusicOn;
        AudioListener.volume = gameDataSO.musicVolume;
        
    }
    private void Start()
    {
        
    }


    private void OnEnable()
    {
        gameDataSO.onGameLose.AddListener(DieSFX);
        gameDataSO.onGameLose.AddListener(StoppingBG);
        gameDataSO.onGameVon.AddListener(WinSFX);
        gameDataSO.DyingEnemy.AddListener(StopEnemyMusic);
        gameDataSO.OnSeeingEnemy.AddListener(PlayEnemyMusic);
    }

    private void OnDisable()
    {
        gameDataSO.onGameLose.RemoveListener(DieSFX);
        gameDataSO.onGameVon.RemoveListener(WinSFX);
        gameDataSO.onGameLose.RemoveListener(StoppingBG);
        gameDataSO.DyingEnemy.RemoveListener(StopEnemyMusic);
        gameDataSO.OnSeeingEnemy.RemoveListener(PlayEnemyMusic);
    }


    public void JumpSFX()
    {
        jumpFX.Play();
    }

    public void RunFX(bool isMoving,bool onGround)
    {
        if (isMoving && onGround && !runFX.isPlaying)
        {
            runFX.Play();
        }
        else if (!isMoving && runFX.isPlaying || !onGround)
        {
            runFX.Stop();
        }
    }

    public void DieSFX()
    {
        dieFX.Play();
    }

    public void WinSFX()
    {
        winFX.Play();
    }

    public void AttackFX()
    {
        attackFX.Play();
    }

    public void ExplosionSFX()
    {
        explosionSFX.Play();
    }

    public void PlayEnemyMusic()
    {
         nearEnemySfx.Play();
        bgMusic.Stop();
        
    }
    public void StopEnemyMusic()
    {
        nearEnemySfx.Stop();
        bgMusic.Play();
    }



    public void StoppingBG()
    {
        bgMusic.Stop();
    }

    public void SettingVolume(float volume)
    {
        AudioListener.volume= volume;
       
    }

    public void settingMute(bool isOn)
    {
        bgMusic.mute=isOn;
    }


    
}
