using Unity.VisualScripting;
using UnityEngine;

public class CrateGun : MonoBehaviour
{
    public ObjectPooler Pooler;
    public int time = 2;
    public int rate = 1;
    

    private void Start()
    {
        InvokeRepeating("ShootCrate", time, rate);
    }

    public void ShootCrate()
    {
        GameObject crate = Pooler.GetPooledCrate();

        if (crate != null)
        {
            crate.transform.position = transform.position;
            crate.transform.rotation = transform.rotation;
            crate.SetActive(true);


        }
    }
}
