using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unrotate : MonoBehaviour
{
    [SerializeField] Transform parent;

    // Update is called once per frame
    void Update()
    {
        transform.localRotation = Quaternion.Euler(0,0, -parent.localRotation.eulerAngles.z);
    }
}
