using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathroomTrigger : MonoBehaviour
{
    public GameObject toothbrush;
    private void OnTriggerEnter(Collider other)
    {
        EventSystem.RaiseEvent(EventType.NEXT_TASK);
        Destroy(this);
    }
}
