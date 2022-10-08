using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathroomWall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        EventSystem<int>.Subscribe(EventType.TASK_NUMBER, OpenWall);
    }

    void OpenWall(int taskNumber)
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
