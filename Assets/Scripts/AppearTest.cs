using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearTest : MonoBehaviour
{

    public GameObject eventcubeplis;
    public Animator tada;


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
        tada.SetBool("IsHere", true);
    }
}
