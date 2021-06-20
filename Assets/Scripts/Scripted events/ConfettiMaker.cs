using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfettiMaker : MonoBehaviour
{
    public Animator GoblinThing;
    public ParticleSystem Confetti;
    public AudioSource radio;
    public AudioSource creepySound;

    void OnTriggerEnter()
    {
       if(GoblinThing.GetBool("IsActive"))
        {
            FindObjectOfType<ToDoList>().NextTask();
            Confetti.Play();
            GetComponent<AudioSource>().Play();
            FindObjectOfType<toothbrush>().ResetExposure();
            radio.Stop();
            creepySound.Stop();
            FindObjectOfType<PlayerMove>().speed = 6;
            Destroy(this);
        }
    }
}
