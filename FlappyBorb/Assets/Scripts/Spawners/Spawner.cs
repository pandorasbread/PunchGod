using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float maxTime = 1;
    protected float nextSpawnTimer;
    protected float differenceDown; 
    protected float differenceUp;


    public float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        nextSpawnTimer = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (CanSpawn() && timer > nextSpawnTimer)
        {
            Spawn();
            VarySpawnTime();
            timer = 0;
        }

        timer += Time.deltaTime;
        
    }

    public virtual void Spawn()
    {

    }

    public virtual void SetSpawnTimers(float diffDown, float diffUp) {
        differenceDown = diffDown;
        differenceUp = diffUp;
    }

    public virtual void VarySpawnTime() {
        nextSpawnTimer = Random.Range(maxTime - differenceDown, differenceUp + maxTime);
        print($"next spawn timer is {nextSpawnTimer}");
    }

    public virtual bool CanSpawn() { return true; }

}
