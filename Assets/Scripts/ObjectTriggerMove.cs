using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTriggerMove : MonoBehaviour
{
    public Transform moveTransform;
    public Transform targetTransform;
    public float animSpeed = 3f;
    public float timeRemainOpen = 5f;
    private Vector3 originalPosition;
    private bool goToTarget;
    private bool goToOriginal;

    private AudioSource audio;
    private void Awake()
    {
        audio = GetComponent<AudioSource>();
        targetTransform.gameObject.SetActive(false);
        originalPosition = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (transform.position == originalPosition && other.CompareTag("Player"))
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
                goToTarget = false;
            }
        }
    }
}
