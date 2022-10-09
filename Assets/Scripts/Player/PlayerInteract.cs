using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private TMP_Text interactText;
    private bool displayingText;

    private void Update()
    {
        if (!MenuManager.Instance.pauseMenuOn)
        {
            RaycastHit hit;
            LayerMask mask = LayerMask.GetMask("interactable");

            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 5f, mask)) {
                if(!displayingText)
                {
                    interactText.gameObject.SetActive(true);
                    interactText.text = "Press " + InputManager.Instance.interactKey + " to " + hit.transform.gameObject.GetComponent<IInteractable>().displayText();
                    displayingText = true;
                }
            
                if (Input.GetKeyDown(InputManager.Instance.interactKey))
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
}
