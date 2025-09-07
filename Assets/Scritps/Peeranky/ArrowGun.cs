using UnityEngine;

public class ArrowGun : MonoBehaviour
{
    public ObjectPooler Pooler;
    public int time=2;
    public int rate=1;
    public float forceAmount;

    private void Start()
    {
        InvokeRepeating("Shooting", time, rate);
    }



    private void Shooting()
    {
        GameObject arrow = Pooler.GetPooledObject();

        if (arrow != null)
        {
            arrow.transform.position = transform.position;
            arrow.transform.rotation = transform.rotation; // Align with shooter's direction
            arrow.SetActive(true);

            Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                
                rb.linearVelocity = transform.right * forceAmount;
            }
        }
    }
}
