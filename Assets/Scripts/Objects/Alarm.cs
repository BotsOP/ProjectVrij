using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioClip alarmSound;
    [SerializeField] private AudioClip alarmSmack;
    [SerializeField] private AudioSource alarm;
    private void Start()
    {
        StartCoroutine("AlarmSounds");
    }

    private IEnumerator AlarmSounds()
    {
        alarm.Play();
        yield return new WaitForSeconds(3f);
        alarm.clip = alarmSmack;
        alarm.Play();
    }
}
