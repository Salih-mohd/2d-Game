using UnityEngine;

public class ForBooks : MonoBehaviour
{
    [SerializeField] private CanvasGroup collectBookButtonCg;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private GameDataSO gameDataSO;
    

    void Awake()
    {
        
        uiManager.HideButton(collectBookButtonCg);
       
    }

    

    

    void Start()
    {
        
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            uiManager.ShowButton(collectBookButtonCg);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            uiManager.HideButton(collectBookButtonCg);
    }


    

    



    
}
