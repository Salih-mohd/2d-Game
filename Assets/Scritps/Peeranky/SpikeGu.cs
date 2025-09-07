using UnityEngine;

public class SpikeGu : MonoBehaviour
{
    public ObjectPooler Pooler;
    public int time = 2;
    public int rate = 1;


    private void Start()
    {
        InvokeRepeating("ShootSpike", time, rate);
    }

    public void ShootSpike()
    {
        GameObject spike = Pooler.GetPooledSpike();

        if (spike != null)
        {
            spike.transform.position = transform.position;
            spike.transform.rotation = transform.rotation;
            spike.SetActive(true); 


        }
    }
}
