using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Portal : MonoBehaviour
{
    public GameObject player;
    public Transform targerPosition;
    public SpriteRenderer playerRenderor;
    public InputActionAsset inputActions;
    public float speed;
    public bool isStartedFading;



    private void Update()
    {
        if (isStartedFading)
        {
            Color c = playerRenderor.color;
            c.a -= Time.deltaTime * speed;
            playerRenderor.color = c;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isStartedFading = true;
            StartCoroutine("Porting");

        }
    }

    


    IEnumerator Porting()
    {
        inputActions.FindActionMap("Player").Disable();
        yield return new WaitForSeconds(2);
        inputActions.FindActionMap("Player").Enable();
        player.transform.position=targerPosition.position;
        isStartedFading=false;
       Color c= playerRenderor.color;
        c.a = 1;
        playerRenderor.color= c;
    }
}
