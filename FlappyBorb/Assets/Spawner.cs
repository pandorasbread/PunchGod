using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float maxTime = 1;
    public float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CanSpawn() && timer > maxTime)
        {
            Spawn();
            timer = 0;
        }

        timer += Time.deltaTime;
    }

    public virtual void Spawn()
    {

    }

    public virtual bool CanSpawn() { return true; }

}
