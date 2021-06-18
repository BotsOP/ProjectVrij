using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathroomTrigger : MonoBehaviour
{
    public GameObject toothbrush;
    private void OnTriggerEnter(Collider other)
    {
        toothbrush.SetActive(true);
        FindObjectOfType<ToDoList>().NextTask();
        Destroy(this);
    }
}
