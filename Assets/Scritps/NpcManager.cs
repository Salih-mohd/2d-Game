using UnityEngine;

public class NpcManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    [SerializeField] private CanvasGroup interactButton;
    [SerializeField] private UIManager uiManager;

    private void Awake()
    {
        uiManager.HideButton(interactButton);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            uiManager.ShowButton(interactButton);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            uiManager.HideButton(interactButton);
    }


}
