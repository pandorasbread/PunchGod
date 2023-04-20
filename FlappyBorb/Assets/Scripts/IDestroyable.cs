using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDestroyable
{
    int Health {get; set;}
    void TakeDamage(int damage);

    void GetDestroyed();
}
