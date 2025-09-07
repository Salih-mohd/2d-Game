using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public GameObject arrowPrefab;
    public GameObject cratePrefab;
    public GameObject spikePrefab;
    public int arrowCount;

    private List<GameObject> arrowPool;
    private List<GameObject> cratePool;
    private List<GameObject> spikePool;
    public bool isCratePoolOpen;
    public bool isSpikePoolOpen;

    private void Start()
    {
        arrowPool = new List<GameObject>();
        cratePool=new List<GameObject>();
        spikePool=new List<GameObject>();

        for (int i = 0; i < arrowCount; i++)
        {
            GameObject obj = Instantiate(arrowPrefab);
            obj.SetActive(false);
            arrowPool.Add(obj);
        }

        if(isCratePoolOpen)
        {
            for (int i = 0; i < arrowCount; i++)
            {
                GameObject obj = Instantiate(cratePrefab);
                obj.SetActive(false);
                cratePool.Add(obj);
                
            }
            
        }

        if(isSpikePoolOpen)
        {
            for (int i = 0; i < arrowCount; i++)
            {
                GameObject obj = Instantiate(spikePrefab);
                obj.SetActive(false);
                spikePool.Add(obj);

            }
        }

    }

    public GameObject GetPooledObject()
    {
        foreach (var obj in arrowPool)
        {
            if (!obj.activeInHierarchy)
                return obj;
        }

        return null; // Optional: expand pool here
    }

    public GameObject GetPooledCrate()
    {
        foreach (var obj in cratePool)
        {
            if (!obj.activeInHierarchy)
                return obj;
        }

        return null;
    }


    public GameObject GetPooledSpike()
    {
        foreach (var obj in spikePool)
        {
            if (!obj.activeInHierarchy)
                return obj;
        }

        return null;
    }
}
