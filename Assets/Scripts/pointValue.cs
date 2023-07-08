using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointValue : MonoBehaviour
{
    public int points;
    [SerializeField] float deathDelay;

    public void die()
    {
        GetComponent<Animator>().SetBool("dead", true);
        StartCoroutine(delayDestroy());
    }

    IEnumerator delayDestroy()
    {
        yield return new WaitForSeconds(deathDelay);
        Destroy(gameObject);
    }
}
