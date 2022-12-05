using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRigidbody;
    public float runSpeed = 1.0f;
    public float jumpStrength = 1.0f;

    private LayerMask ground_layers;
    private bool isOnGround = true;
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += (new Vector3(Input.GetAxisRaw("Horizontal") * runSpeed * Time.deltaTime, 0, 0));
        if (Input.GetKey(KeyCode.Space) == true && isOnGround == true)
        {
            playerRigidbody.velocity = new Vector2(0.0f,1.0f) * jumpStrength; 
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) { 
        if (collision.gameObject.tag == "Ground" && (playerRigidbody.velocity.y == 0.0f)) { 
            isOnGround = true;
        } 
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isOnGround = false;
    }
}
