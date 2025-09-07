using UnityEngine;

public class RotatingSpike : MonoBehaviour
{

    public float rotationSpeed;
    private void Update()
    {
        transform.Rotate(0,0,rotationSpeed*Time.deltaTime);
    }
}
