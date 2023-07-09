using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endCutscene : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(count());
    }


    IEnumerator count()
    {

        yield return new WaitForSeconds(4.5f);
        SceneManager.LoadScene(0);
    }
}
