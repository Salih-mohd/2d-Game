using UnityEngine;

public class DestroyGrounds : MonoBehaviour
{
    [SerializeField] private ParticleSystem ps;
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("crate"))
        {
            ps.Play();
            AudioManager.Instance.ExplosionSFX();
            
            
            collision.gameObject.SetActive(false);
            gameObject.SetActive(false);
        }
    }

}
