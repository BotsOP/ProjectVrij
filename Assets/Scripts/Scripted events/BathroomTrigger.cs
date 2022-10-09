using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathroomTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        EventSystem.RaiseEvent(EventType.NEXT_TASK);
        Destroy(this);
    }
}
