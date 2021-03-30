using Photon.Pun;
using UnityEngine;

public class Player : MonoBehaviourPun
{
    private Rigidbody2D playerRigidbody;
    private SpriteRenderer spriteRenderer;
    
    public float speed = 3f;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        if(photonView.IsMine)
        {
            spriteRenderer.color = Color.blue;
        }
        else 
        {
            spriteRenderer.color = Color.red;
        }
    }

    private void Update()
    {
        if(!photonView.IsMine) // 현재 player가 local이 아니라면 
        {
            return;
        }

        var distance = -1 * speed * Time.deltaTime;
        // var targetPosition = transform.position + Vector3.up * distance;
        var targetPosition = transform.position + Vector3.right * distance;

        playerRigidbody.MovePosition(targetPosition);
    }
}
