using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpookHappening : MonoBehaviour
{
    public GameObject spook;
    public Animator spookAnimator;
    public AudioSource radio1;

    void OnTriggerEnter()
    {
        radio1.Play();
        spookAnimator.SetBool("IsActive", true);
    }
}
