using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfettiMaker : MonoBehaviour
{
    public Animator GoblinThing;
    public ParticleSystem Confetti;

    void OnTriggerEnter()
    {
       if(GoblinThing.GetBool("IsActive") == true)
        {
            FindObjectOfType<ToDoList>().NextTask();
            Confetti.Play();
        }
    }
}
