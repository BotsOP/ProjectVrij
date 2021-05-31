using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRaycastInteract : MonoBehaviour, IInteractable
{
    public Transform moveTransform;
    public Transform targetTransform;
    public float animSpeed = 3f;
    public float timeRemainOpen = 5f;
    private Vector3 originalPosition;
    private bool goToTarget;
    private bool goToOriginal;

    private void Awake()
    {
        targetTransform.gameObject.SetActive(false);
        originalPosition = transform.position;
    }
    
    public void Interact()
    {
        if (transform.position == originalPosition)
        {
            goToTarget = true;
        }
    }

    private void Update()
    {
        if (goToTarget)
        {
            moveTransform.position = Vector3.Lerp(moveTransform.position, targetTransform.position, Time.deltaTime * animSpeed);
            if (Vector3.Distance(moveTransform.position, targetTransform.position) < 0.01f)
            {
                moveTransform.position = targetTransform.position;
                StartCoroutine("GoBackToOriginal");
                goToTarget = false;
            }
        }
        
        if (goToOriginal)
        {
            moveTransform.position = Vector3.Lerp(moveTransform.position, originalPosition, Time.deltaTime * animSpeed);
            if (Vector3.Distance(moveTransform.position, originalPosition) < 0.01f)
            {
                moveTransform.position = originalPosition;
                goToOriginal = false;
            }
        }
    }

    private IEnumerator GoBackToOriginal()
    {
        yield return new WaitForSeconds(timeRemainOpen);
        goToOriginal = true;
    }
}
