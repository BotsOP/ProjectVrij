using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToDoList : MonoBehaviour
{
    public GameObject crossingThrough;
    public GameObject[] toDoList;
    private int currentToDoItem;

    private void Start()
    {
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
    }
}
