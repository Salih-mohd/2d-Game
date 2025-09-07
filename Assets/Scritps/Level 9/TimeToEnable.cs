using UnityEngine;

public class TimeToEnable : MonoBehaviour
{
    public GameObject effector;
    public GameObject pooler;
    public GameObject crateGun;


    private void Awake()
    {
        effector.SetActive(false);
        pooler.SetActive(false);
        crateGun.SetActive(false);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("crate"))
        {
            effector.SetActive(true);
            pooler.SetActive(true);
            crateGun.SetActive(true);
            
        }
    }
}
