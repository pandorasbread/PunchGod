using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurdleSpawner : Spawner
{
    public GameObject Hurdle;
    public float hCenter;

    // Start is called before the first frame update
    void Start()
    {
        SetSpawnTimers(.5f, .3f);
    }

    public override void Spawn()
    {
        GameObject newhurdle = Instantiate(Hurdle);
        newhurdle.transform.position = transform.position + new Vector3(Random.Range(-hCenter, hCenter), 0, 0);
        Destroy(newhurdle, 15);
        
    }

}
