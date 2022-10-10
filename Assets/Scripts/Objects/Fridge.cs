using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fridge : MonoBehaviour, IInteractable
{
    [SerializeField] private string displayText;
    public void Interact()
    {
        EventSystem.RaiseEvent(EventType.NEXT_TASK);
        gameObject.layer = 0;
        Destroy(this);
    }
    public string DisplayText()
    {
        return displayText;
    }
}
