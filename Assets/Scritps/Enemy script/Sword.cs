using UnityEngine;

public class Sword : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth.instance.DecreaseHealth(2);
        }
    }
}
