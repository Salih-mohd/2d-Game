using UnityEngine;

public class FlyingCrate : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("disableArrow"))
            gameObject.SetActive(false);
    }
}
