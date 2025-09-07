using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private UIManager uimanager;
    public static PlayerHealth instance;

    private void Awake()
    {
        instance = this;
    }
    

    public void DecreaseHealth(int value)
    {
        uimanager.DecreaseHealth(value);
    }
}
