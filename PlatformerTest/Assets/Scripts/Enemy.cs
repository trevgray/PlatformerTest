using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D enemyRigidbody;
    private int patrolDirection = 1;
    public float moveSpeed = 5;

    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        enemyRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyRigidbody.velocity.x == 0)
        {
            patrolDirection = -patrolDirection;
        }
        enemyRigidbody.velocity = new Vector2(moveSpeed * patrolDirection, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.GetComponent<Rigidbody2D>().velocity.y < 0)
            {
                Destroy(gameObject);
            }
            else
            {
                gameManager.ToggleDeathScreen();
            }
        }
    }
}
