using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toothbrush2 : MonoBehaviour, IInteractable
{
    public string _displayText;
    public GameObject otherToothbrush;
    public Transform sphereSpawnPos;
    public GameObject fallingDownStairsSphere;
    private bool hasActivated;
    public void Interact()
    {
        if (!hasActivated)
        {
            otherToothbrush.SetActive(true);
            FindObjectOfType<ToDoList>().NextTask();
            GameObject sphere = Instantiate(fallingDownStairsSphere, sphereSpawnPos.position, Quaternion.identity);
            Destroy(sphere, 3f);
            Destroy(gameObject, 3.1f);
            hasActivated = true;
        }
    }
    public string displayText()
    {
        return _displayText;
    }
}
