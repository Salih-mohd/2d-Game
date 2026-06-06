using UnityEngine;
using UnityEngine.InputSystem;

public class ArrowDisable : MonoBehaviour
{
    public int speed;
    public InputActionAsset inputActions;
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("disableArrow"))
       gameObject.SetActive(false);
    }
}
