using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpwaner : MonoBehaviour
{
    public GameObject zombie;
    public GameObject bigZombie;
    public GameObject smallZombie;
    public int alreadySpawn = 0;
    public float nextspawn = 0f;
    public float spawnCooldown = 1f;
    public int[] enemyperwave = {5, 10, 15, 20, 25, 30, 35, 40, 45, 55};

    private void Update() {
        if(GameManager.instance.ongoingwave == true && Time.time >= nextspawn){
            Spawn();
            nextspawn = Time.time+spawnCooldown;
        }
    }

    private void Spawn()
    {
        alreadySpawn++;
        GameManager.instance.enemycnt++;
        SpawnLocation(zombie);
        if (GameManager.instance.wave >= 5 && alreadySpawn % 5 == 0)
        {
            SpawnLocation(bigZombie);
        }
        else if (GameManager.instance.wave >= 7 && alreadySpawn % 10 == 0)
        {
            SpawnLocation(smallZombie);
        }

        if(alreadySpawn == enemyperwave[GameManager.instance.wave - 1])
        {
            GameManager.instance.ongoingwave = false;
            alreadySpawn = 0;
        }
    }

    private void SpawnLocation(GameObject enemyprefab)
    {
        int location = Random.Range(1, 5);
        if(location == 1){
            float locationy = Random.Range(4f, -4f);
            Instantiate(enemyprefab, new Vector3(8, locationy, 0),  new Quaternion(0, 0, 0, 0));
        }
        else if(location == 2){
            float locationx = Random.Range(8f, -8f);
            Instantiate(enemyprefab, new Vector3(locationx, 4, 0),  new Quaternion(0, 0, 0, 0));
        }
        else if(location == 3){
            float locationy = Random.Range(4f, -4f);
            Instantiate(enemyprefab, new Vector3(-8, locationy, 0),  new Quaternion(0, 0, 0, 0));
        }
        else if(location == 4){
            float locationx = Random.Range(8f, -8f);
            Instantiate(enemyprefab, new Vector3(locationx, -4, 0),  new Quaternion(0, 0, 0, 0));
        }
    }
}
