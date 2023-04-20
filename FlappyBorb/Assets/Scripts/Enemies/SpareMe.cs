using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpareMe : Enemy
{
    private Rigidbody2D body;
    public override int Tier => 1;

    private float timeAlive = 0;
    private float baseSpeed = 4f;
    private Vector2 nextForce;
    public override void InitializeEnemy()
    {
        body = GetComponent<Rigidbody2D>();
        Health = 5;
    }

    public override void Move()
    {
        if ((int)timeAlive % 1 == 0) {
            body.AddForce(nextForce);
            VaryTrajectoryTime();
        }
        timeAlive += Time.deltaTime;
        print(timeAlive);
        base.Move();
    }

    private void VaryTrajectoryTime() {
        nextForce = new Vector2(Random.Range(-baseSpeed, baseSpeed), Random.Range(-baseSpeed, baseSpeed));
    }

}
