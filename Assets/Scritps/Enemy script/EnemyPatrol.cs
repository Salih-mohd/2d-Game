using UnityEngine;
using UnityEngine.Splines;
using UnityEngine.UI;


public class EnemyPatrol : MonoBehaviour
{
    public SplineContainer spline;
    public float speed = 2f;
    public Slider enemyHealthBar;


    private float t = 0f; // represents the position
    private bool movingForward = true;

    void Update()
    {
        if (spline == null) return;

        
        float delta = (speed / spline.CalculateLength()) * Time.deltaTime; 
        t += movingForward ? delta : -delta;

        if (t >= 1f)
        {
            t = 1f;
            movingForward = false;
            Flip();
            enemyHealthBar.direction = Slider.Direction.RightToLeft;
        }
        else if (t <= 0f)
        {
            t = 0f;
            movingForward = true;
            Flip();
            enemyHealthBar.direction=Slider.Direction.LeftToRight;
        }

        
        transform.position = spline.EvaluatePosition(t);
    }

    void Flip()
    {

        
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
