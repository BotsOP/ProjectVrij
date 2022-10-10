using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class ConfettiMaker : MonoBehaviour
{
    [SerializeField] private ParticleSystem confetti;
    [SerializeField] private Volume volume;
    
    private ColorAdjustments colorAdjustments;

    private void Start()
    {
        EventSystem<int>.Subscribe(EventType.TASK_NUMBER, ActivateCollider);
        volume.profile.TryGet(out colorAdjustments);
    }

    private void ActivateCollider(int taskNumber)
    {
        if (taskNumber == 5)
        {
            GetComponent<BoxCollider>().enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        EventSystem.RaiseEvent(EventType.NEXT_TASK);
        EventSystem.RaiseEvent(EventType.PARTY);

        confetti.Play();
        GetComponent<AudioSource>().Play();
        colorAdjustments.postExposure.value = 0;
        EventSystem<float>.RaiseEvent(EventType.CHANGE_PLAYER_SPEED, 6f);
       
        Destroy(this);
    }
}
