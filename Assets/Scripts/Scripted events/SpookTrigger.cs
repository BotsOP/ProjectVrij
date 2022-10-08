using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpookTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        EventSystem.RaiseEvent(EventType.ENTER_LIVINGROOM);
        
        Destroy(this);
    }
}
