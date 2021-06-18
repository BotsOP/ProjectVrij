using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hamburger : MonoBehaviour, IInteractable
{
    public string _displayText;
    public Transform radio;
    public Transform newRadio;
    private bool hasEaten;
    public void Interact()
    {
        hasEaten = true;
        FindObjectOfType<ToDoList>().NextTask();
        GetComponent<AudioSource>().Play();
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
    private void Update()
    {
        if (hasEaten)
        {
            radio.position = Vector3.Lerp(radio.position, newRadio.position, Time.deltaTime);
        }
    }
    public string displayText()
    {
        return _displayText;
    }
}
