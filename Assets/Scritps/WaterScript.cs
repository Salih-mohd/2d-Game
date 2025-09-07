using UnityEngine;

public class WaterScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManger.Instance.GameLoseInvoke();
            collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            collision.gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        }
    }
}
