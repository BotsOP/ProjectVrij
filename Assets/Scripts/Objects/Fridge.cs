using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fridge : MonoBehaviour, IInteractable
{
    public string _displayText;
    public GameObject Hamburger;
    public void Interact()
    {
        Hamburger.SetActive(true);
        EventSystem.RaiseEvent(EventType.NEXT_TASK);
        gameObject.layer = 0;
        Destroy(this);
    }
    public string displayText()
    {
        return _displayText;
    }
}
