using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour
{
    [SerializeField] private AudioSource radio;
    [SerializeField] private Transform newRadioPos;
    private bool eatenBurger;

    void Start()
    {
        EventSystem.Subscribe(EventType.ENTER_LIVINGROOM, StartRadio);
        EventSystem.Subscribe(EventType.PARTY, StopRadio);
        EventSystem<int>.Subscribe(EventType.TASK_NUMBER, MoveRadio);
    }

    private void StartRadio()
    {
        radio.Play();
        Debug.Log("activated radio");
    }
    
    private void MoveRadio(int taskNumber)
    {
        if (taskNumber == 2)
        {
            eatenBurger = true;
        }
    }

    private void StopRadio()
    {
        radio.Stop();
    }

    private void Update()
    {
        if (eatenBurger)
        {
            transform.position = Vector3.Lerp(transform.position, newRadioPos.position, Time.deltaTime);
        }
    }
}
