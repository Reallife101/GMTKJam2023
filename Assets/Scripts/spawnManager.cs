using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    //How many enemies do we want on screen at once?
    [SerializeField] int spawnCount;

    [SerializeField] GameObject parentSpawn;
    [SerializeField] GameObject[] enemies;

    private void Start()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            spawn();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GameObject[] go = GameObject.FindGameObjectsWithTag("enemy");

        if (go.Length < spawnCount)
        {
            spawn();
        }
    }

    void spawn()
    {
        Transform t = parentSpawn.transform.GetChild(Random.Range(0, parentSpawn.transform.childCount));
        Instantiate(enemies[Random.Range(0, enemies.Length)], t.position, Quaternion.identity);
    }
}
