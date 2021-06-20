using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearTest : MonoBehaviour
{

    public GameObject eventcubeplis;
    public Animator tada;

    void OnTriggerEnter()
    {
        tada.SetBool("IsHere", true);
    }
}
