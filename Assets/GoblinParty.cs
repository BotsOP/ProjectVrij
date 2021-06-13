using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinParty : MonoBehaviour
{
    public Animator GoblinAnimator;

    void OnTriggerEnter()
    {
        GoblinAnimator.SetBool("IsActive", true);
    }
}
