using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hamburger : MonoBehaviour, IInteractable
{
    public string _displayText;
    public Transform radio;
    public Transform newRadio;
    public GameObject wall;
    private bool hasEaten;
    public void Interact()
    {
        wall.SetActive(false);
        hasEaten = true;
        FindObjectOfType<ToDoList>().NextTask();
        GetComponent<AudioSource>().Play();
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
        gameObject.layer = 0;
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
