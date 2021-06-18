using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class toothbrush : MonoBehaviour, IInteractable
{
    public Volume volume;
    public GameObject toothbrushText;
    public string _displayText;
    public Animator GoblinAnimator;
    private bool hasBrushedTeeth;
    private ColorAdjustments colorAdjustments;
    private float exposureValue;
    
    void Start()
    {
        volume.profile.TryGet<ColorAdjustments>(out colorAdjustments);
    }
    
    public void Interact()
    {
        if (!hasBrushedTeeth)
        {
            gameObject.layer = 0;
            GoblinAnimator.SetBool("IsActive", true);
            FindObjectOfType<ToDoList>().NextTask();
            StartCoroutine("BrushingTeeth");
            hasBrushedTeeth = true;
        }
    }

    private void FixedUpdate()
    {
        Debug.Log(hasBrushedTeeth);
        if (hasBrushedTeeth)
        {
            exposureValue -= 0.015f;
            colorAdjustments.postExposure.value = exposureValue;
            if (colorAdjustments.postExposure.value <= -3.25f)
            {
                hasBrushedTeeth = false;
            }
        }
    }

    public void ResetExposure()
    {
        colorAdjustments.postExposure.value = 0;
    }

    public string displayText()
    {
        return _displayText;
    }

    private IEnumerator BrushingTeeth()
    {
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1f);
        GetComponent<AudioSource>().Stop();
        FindObjectOfType<ToDoList>().NextTask();
        toothbrushText.SetActive(true);
        yield return new WaitForSeconds(3f);
        toothbrushText.SetActive(false);
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(false);
    }
}
