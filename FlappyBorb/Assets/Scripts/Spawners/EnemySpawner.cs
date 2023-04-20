using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    public GameObject enemyType;
    public float spawnX;
    public float spawnY;
    // Start is called before the first frame update
    void Start()
    {
        SetSpawnTimers(0,0);
    }

    public override void Spawn()
    {
        spawnY = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height-50)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height-20)).y);
        spawnX = Random.Range(Camera.main.ScreenToWorldPoint(new Vector2(Screen.width*.35f, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width*.65f,0)).x);
        GameObject enemy = Instantiate(enemyType, new Vector3(spawnX,spawnY,0), Quaternion.identity);
        
    }
    
    public override bool CanSpawn(){

        return GameObject.FindGameObjectsWithTag("Enemy").Length < 6;
    }
}
