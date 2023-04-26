using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseAspect : MonoBehaviour
{
    protected Animator animator;
    protected Rigidbody2D body;
    public float AttackInterval {get;set;}
    private float _timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        SetAttackInterval();
        print("initalized aspect");
    }

    // Update is called once per frame
    void Update()
    {
        if (_timer > AttackInterval)
        {
            InitializeAttack();
            AnimateAttack();
            _timer = 0;
        }

        print("timer is " +_timer);
        _timer += Time.deltaTime;
    }

    public abstract void InitializeAttack();

    public abstract void SetAttackInterval();

    public virtual void AnimateAttack() {
        
    }

}
