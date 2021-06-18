using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerInteract : MonoBehaviour
{
    public TMP_Text interactText;
    public Camera mainCamera;
    bool displayingText;
    void Start()
    {
        mainCamera = GetComponent<Camera>();
    }

    void Update()
    {
        RaycastHit hit;
        LayerMask mask = LayerMask.GetMask("interactable");
    
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward,out hit, 5f, mask)) {
            if(!displayingText)
            {
                interactText.gameObject.SetActive(true);
                interactText.text = "Press E to " + hit.transform.gameObject.GetComponent<IInteractable>().displayText();
                displayingText = true;
            }
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                hit.transform.gameObject.GetComponent<IInteractable>().Interact();
            }
        }
        else
        {
            if(displayingText)
            {
                interactText.gameObject.SetActive(false);
                displayingText = false;
            }
        }
    }
}
