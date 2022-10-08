using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hamburger : MonoBehaviour, IInteractable
{
    [SerializeField] private string _displayText;
    [SerializeField] private MeshRenderer[] hamburgerRend;
    private bool hasEaten;

    private void Start()
    {
        EventSystem<int>.Subscribe(EventType.TASK_NUMBER, ActivateHamburger);
    }
    public void Interact()
    {
        if (!hasEaten)
        {
            hasEaten = true;
            EventSystem.RaiseEvent(EventType.NEXT_TASK);
            GetComponent<AudioSource>().Play();
            
            foreach (var rend in hamburgerRend)
            {
                rend.enabled = false;
            }
            
            gameObject.layer = 0;
        }
    }
    private void ActivateHamburger(int taskNumber)
    {
        Debug.Log(taskNumber);
        if (taskNumber == 1)
        {
            foreach (var rend in hamburgerRend)
            {
                rend.enabled = true;
            }
        }
    }
    public string displayText()
    {
        return _displayText;
    }
}
