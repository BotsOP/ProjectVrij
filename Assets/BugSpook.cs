using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugSpook : MonoBehaviour
{
    public Animator spookAnimator;

    void Start()
    {
        EventSystem.Subscribe(EventType.ENTER_LIVINGROOM, StartRadio);
    }

    private void StartRadio()
    {
        spookAnimator.SetBool("IsActive", true);
        Debug.Log("activated radio");
    }
}
