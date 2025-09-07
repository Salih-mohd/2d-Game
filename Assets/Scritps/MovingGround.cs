using UnityEngine;

public class MovingGround : MonoBehaviour
{

    [SerializeField] private Vector3 a, b;
    [SerializeField] private float speed;
    [SerializeField] private AnimationCurve ease = AnimationCurve.Linear(0, 0, 1, 1);


    private Rigidbody2D rb;
    
    private float tBase;
    private float length;

    private void Awake()
    {
        
        length = 1f;
        rb = GetComponent<Rigidbody2D>();
        rb.interpolation=RigidbodyInterpolation2D.Interpolate;
        tBase = 0f;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        MovingUpAndDown();
    }

    private void MovingUpAndDown()
    {
        tBase += Time.fixedDeltaTime * speed;
        float t = Mathf.PingPong(tBase, length) / length;
        float k = ease.Evaluate(t);
        Vector3 target = Vector3.LerpUnclamped(a, b, k);
        rb.MovePosition(target);
    }
}
