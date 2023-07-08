using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skidHandler : MonoBehaviour
{
    [SerializeField] carController cc;

    TrailRenderer tr;

    void Awake()
    {
        tr = GetComponent<TrailRenderer>();
        tr.emitting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (cc.drifting)
        {
            tr.emitting = true;
        }
        else
        {
            tr.emitting = false;
        }
    }
}
