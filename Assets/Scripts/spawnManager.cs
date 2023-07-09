using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    //How many enemies do we want on screen at once?
    [SerializeField] int spawnCount;

    [SerializeField] GameObject parentSpawn;
    [SerializeField] GameObject[] enemies;

    List<Transform> spawnLocs;
    int index = 0;

    private void Start()
    {
        spawnLocs = new List<Transform>();
        foreach (Transform child in parentSpawn.transform)
        {
            spawnLocs.Add(child);
        }

        int n = spawnLocs.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n);
            Transform value = spawnLocs[k];
            spawnLocs[k] = spawnLocs[n];
            spawnLocs[n] = value;
        }

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
        //Transform t = parentSpawn.transform.GetChild(Random.Range(0, parentSpawn.transform.childCount));
        Transform t = spawnLocs[index];
        index++;
        if (index >= spawnLocs.Count)
        {
            index = 0;
        }
        Instantiate(enemies[Random.Range(0, enemies.Length)], t.position+new Vector3(Random.Range(-.5f, .5f), Random.Range(-.5f, .5f), Random.Range(-.5f, .5f)), Quaternion.identity);
    }
}
