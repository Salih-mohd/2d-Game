using UnityEngine;

public class DealingEffectors : MonoBehaviour
{
    public GameDataSO gameDataSO;
    public AreaEffector2D areaEffector2D;
    public GameObject ParticleSystem;
    private void Awake()
    {
        areaEffector2D.enabled=false;
        ParticleSystem.SetActive(false);
    }
    private void OnEnable()
    {
        gameDataSO.DyingEnemy.AddListener(EnableEffector);
    }

    private void OnDisable()
    {
        gameDataSO.DyingEnemy.RemoveListener(EnableEffector);
    }

    public void EnableEffector()
    {
        if(areaEffector2D != null)
        {
            areaEffector2D.enabled=true;
            ParticleSystem.SetActive(true);
        }
    }



}
