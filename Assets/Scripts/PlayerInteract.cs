using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera mainCamera;
    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        
            if (Physics.Raycast(ray, out hit, 5f)) {
                Debug.Log(hit.transform.gameObject.name);
                if (hit.transform.gameObject.GetComponent<IInteractable>() != null)
                {
                    hit.transform.gameObject.GetComponent<IInteractable>().Interact();
                }
            }
        }
    }
}
