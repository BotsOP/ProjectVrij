using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ConfettiMaker : MonoBehaviour
{
    public Animator GoblinThing;
    public ParticleSystem Confetti; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter()
    {
       if(GoblinThing.GetBool("IsActive") == true)
        {
            Confetti.Play();
        }
    }
}
