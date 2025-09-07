using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Button[] levelButtons;
    [SerializeField] private GameDataSO gameDataSo;
    [SerializeField] private UIManager uIManager;

    private void Start()
    {
        //gameDataSo.ResetProgress();
        int unlockedLevel = gameDataSo.unlockedLevel;
        for (int i = 0; i < levelButtons.Length; i++)
        {
            int level = i + 1;
            levelButtons[i].interactable = (level <= unlockedLevel);
            int levelIndex = level;
            levelButtons[i].onClick.AddListener(() => uIManager.SelectLevel(levelIndex));
        }
    }
}
