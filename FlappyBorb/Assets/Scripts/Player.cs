using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D body;
    private const float playerSpeed = .5f;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        if (body.velocity.y > 6)
            body.velocity = new Vector2(body.velocity.x, 6);
        if (body.velocity.y < -6)
            body.velocity = new Vector2(body.velocity.x, -6);

        if (Input.GetKeyDown("space"))
        {
            print("space key was pressed");
            animator.Play("flap");
            body.velocity += new Vector2(0, 3);
        }

        if (Input.GetKey("a"))
            body.position += Vector2.left * Time.fixedDeltaTime * playerSpeed;

        if (Input.GetKey("d"))
            body.position += Vector2.right * Time.fixedDeltaTime * playerSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "death")
            gameManager.gameOver();
    }
}
