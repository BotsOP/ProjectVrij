using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toothbrush2 : MonoBehaviour, IInteractable
{
    public string _displayText;
    public Transform sphereSpawnPos;
    public GameObject fallingDownStairsSphere;
    [SerializeField] private MeshRenderer[] rends;
    private bool hasActivated;

    private void Start()
    {
        EventSystem<int>.Subscribe(EventType.TASK_NUMBER, ActivateToothBrush);
    }
    public void Interact()
    {
        if (!hasActivated)
        {
            EventSystem.RaiseEvent(EventType.NEXT_TASK);
            GameObject sphere = Instantiate(fallingDownStairsSphere, sphereSpawnPos.position, Quaternion.identity);
            Destroy(sphere, 3f);
            Destroy(gameObject, 3.1f);
            
            foreach (MeshRenderer rend in rends)
            {
                rend.enabled = false;
            }
            
            hasActivated = true;
        }
    }
    private void ActivateToothBrush(int taskNumber)
    {
        if (taskNumber == 3)
        {
            GetComponent<BoxCollider>().enabled = true;
            foreach (MeshRenderer rend in rends)
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
