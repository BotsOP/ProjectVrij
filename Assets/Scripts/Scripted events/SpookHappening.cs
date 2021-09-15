using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpookHappening : MonoBehaviour
{
    void OnTriggerEnter()
    {
        EventSystem.RaiseEvent(EventType.ENTER_LIVINGROOM, null);
        
        Destroy(this);
    }
}
