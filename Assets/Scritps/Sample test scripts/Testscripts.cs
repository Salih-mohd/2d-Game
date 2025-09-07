using UnityEngine;

public class Testscripts : MonoBehaviour
{
    public GameObject prefab;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Instantiate(prefab,transform.position,transform.rotation);
        }
    }
}
