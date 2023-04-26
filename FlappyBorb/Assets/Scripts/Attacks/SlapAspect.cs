using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlapAspect : BaseAspect
{
    public override void SetAttackInterval()
    {
        AttackInterval = 0.66f;
    }
    public override void InitializeAttack() {
        var player = GameObject.FindWithTag("Player");
        print(player.gameObject.transform.position);
        if (player == null) 
            return;
        body.gameObject.SetActive(true);
        body.transform.position = player.gameObject.transform.position + Vector3.right;
        body.transform.RotateAround(player.gameObject.transform.position, Vector3.forward, 180f);
        
    }


}
