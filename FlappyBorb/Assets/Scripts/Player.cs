using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDestroyable   
{
    private Animator animator;
    private Rigidbody2D body;
    private const float playerSpeed = 3f;
    public int Health {get;set;} = 10;
    public GameManager gameManager;


    [SerializeField]
    public List<GameObject> Aspects;

    public int smacc => 5;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        InitializeAspects();

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
            animator.Play("flap");
            body.velocity += new Vector2(0, 3);
        }

        if (Input.GetKey("a"))
            
            body.velocity = new Vector2(-1* playerSpeed, body.velocity.y);

        if (Input.GetKey("d"))
            body.velocity = new Vector2(1* playerSpeed, body.velocity.y);
    }

    public void TakeDamage(int damage) {
        Health--;
    }

    public void GetDestroyed() {
        gameManager.gameOver();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "death")
            GetDestroyed();
            
        if (collision.gameObject.TryGetComponent(out IDestroyable hit)) {
            hit.TakeDamage(smacc);
        }
    }

    private void InitializeAspects() {

        foreach (var aspect in Aspects) {
            Instantiate(aspect, new Vector3(0,0,0), Quaternion.identity);
        }
    }
}