using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    public float runSpeed = 1.0f;
    public float jumpStrength = 1.0f;

    private LayerMask ground_layers;
    private bool isOnGround = false;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += (new Vector3(Input.GetAxisRaw("Horizontal") * runSpeed * Time.deltaTime, 0, 0));
        if (Input.GetKey(KeyCode.Space) == true && isOnGround == true)
        {
            rigidbody2D.velocity += new Vector2(0.0f,1.0f) * jumpStrength; 
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) { 
        if (collision.gameObject.tag == "Ground") { 
            isOnGround = true;
            //rigidbody2D.velocity = new Vector2(0.0f, 0.0f);
        } 
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isOnGround = false;
    }
}
