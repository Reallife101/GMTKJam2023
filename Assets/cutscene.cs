using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cutscene : MonoBehaviour
{
    [SerializeField] GameObject sc1;
    [SerializeField] GameObject sc2;
    [SerializeField] GameObject sc3;
    // Start is called before the first frame update
    void Start()
    {
        sc2.SetActive(false);
        sc3.SetActive(false);
        StartCoroutine(count());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator count()
    {
        sc1.SetActive(true);
        yield return new WaitForSeconds(5f);
        sc1.SetActive(false);
        sc2.SetActive(true);
        yield return new WaitForSeconds(3f);
        sc2.SetActive(false);
        sc3.SetActive(true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(3);
    }
}
