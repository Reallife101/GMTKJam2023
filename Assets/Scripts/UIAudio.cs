using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAudio : MonoBehaviour
{
    [SerializeField] FMODUnity.EventReference uiAudio;

    public void playAudio()
    {
        FMODUnity.RuntimeManager.PlayOneShot(uiAudio);
    }
}
