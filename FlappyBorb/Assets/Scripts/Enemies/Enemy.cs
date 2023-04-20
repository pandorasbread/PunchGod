using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IDestroyable
{

    public int Health {get;set;}

    public abstract int Tier {get; }
    

    // Start is called before the first frame update
    void Start()
    {
        InitializeEnemy();
    }

    public abstract void InitializeEnemy();


    // Update is called once per frame
    void Update()
    {
        Move();    
        if (Health <= 0)
            GetDestroyed();
    }
    
    public virtual void Move() { 

    }

    public virtual void GetDestroyed() {
        Destroy(this.gameObject);
    }
    
    public virtual void TakeDamage(int damage) {
        Health -= damage;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "death")
            GetDestroyed();
    }
}
