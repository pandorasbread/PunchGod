using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    public GameObject enemyType;
    // Start is called before the first frame update
    void Start()
    {
        SetSpawnTimers(0,0);
    }

    public override void Spawn()
    {
        GameObject newhurdle = Instantiate(enemyType);
        newhurdle.transform.position = transform.position + new Vector3(Random.Range(-hCenter, hCenter), 0, 0);        
    }
    
    public override bool CanSpawn(){

        return GameObject.FindGameObjectsWithTag("Enemy").Length < 6;
    }
}
