using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManger : MonoBehaviour
{

    public static GameManger Instance;

    [SerializeField] private InputReader inputReader;
    [SerializeField] private UIManager uiManager;


    private void Awake()
    {
        Instance = this;
    }

    [SerializeField] private GameDataSO gamedataSo;

    private void Start()
    {
        //gamedataSo.ResetProgress();
        gamedataSo.Load();
    }

    private void Update()
    {
        if (inputReader.isPaused)
        {
            uiManager.ShowPauseMenu();
        }
    }




    // Handling events



    public void GameWonInvoke()
    {
        gamedataSo.onGameVon.Invoke();
    }

    public void GameLoseInvoke()
    {
        gamedataSo.onGameLose.Invoke();
    }

   

    






    // Handling scene management

    public void LoadNextLevel(int level)
    {
        gamedataSo.unlockedLevel = level + 1;
        gamedataSo.Save();
        SceneManager.LoadSceneAsync(level + 1);

    }

    public void RestartLevel(int level)
    {
        SceneManager.LoadSceneAsync(level);
    }

    public void ReturnHome()
    {
        SceneManager.LoadSceneAsync(0);
    }


}
