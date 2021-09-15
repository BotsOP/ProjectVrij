using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour
{
    public AudioSource radio;

    void Start()
    {
        EventSystem.Subscribe(EventType.ENTER_LIVINGROOM, StartRadio);
    }

    private void StartRadio()
    {
        radio.Play();
        Debug.Log("activated radio");
    }
}
