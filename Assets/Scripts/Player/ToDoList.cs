using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToDoList : MonoBehaviour
{
    [SerializeField] private GameObject crossingThrough;
    [SerializeField] private GameObject[] toDoList;
    private int currentToDoItem;

    private void Start()
    {
        EventSystem.Subscribe(EventType.NEXT_TASK, NextTask);
        Invoke("SetFirstItemActive", 3f);
    }

    private void SetFirstItemActive()
    {
        toDoList[0].SetActive(true);
    }

    public void NextTask()
    {
        toDoList[currentToDoItem].GetComponent<Animator>().SetBool("finished", true);
        
        GameObject cross = Instantiate(crossingThrough, Vector3.zero, Quaternion.identity, toDoList[currentToDoItem].transform);
        cross.transform.localPosition = new Vector3(0, -21, 0);
        
        currentToDoItem++;
        toDoList[currentToDoItem].SetActive(true);
        
        EventSystem<int>.RaiseEvent(EventType.TASK_NUMBER, currentToDoItem);
    }
}
