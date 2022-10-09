using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepySound : MonoBehaviour
{
    private void Start()
    {
        EventSystem<int>.Subscribe(EventType.TASK_NUMBER, ActivateSound);
        EventSystem.Subscribe(EventType.PARTY, StopSound);
    }

    private void ActivateSound(int taskNumber)
    {
        if (taskNumber == 5)
        {
            GetComponent<AudioSource>().Play();
        }
    }

    private void StopSound()
    {
        GetComponent<AudioSource>().Stop();
    }
}
