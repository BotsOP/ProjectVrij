using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathroomWall : MonoBehaviour
{
    private void Start()
    {
        EventSystem<int>.Subscribe(EventType.TASK_NUMBER, OpenWall);
    }

    private void OpenWall(int taskNumber)
    {
        if (taskNumber == 2)
        {
            Debug.Log($"completed task 2");
            gameObject.SetActive(false);
            
            EventSystem<int>.Unsubscribe(EventType.TASK_NUMBER, OpenWall);
            Destroy(this);
        }
    }
}
