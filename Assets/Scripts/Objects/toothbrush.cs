using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class toothbrush : MonoBehaviour, IInteractable
{
    [SerializeField] private Volume volume;
    [SerializeField] private float darkeningSpeed = 0.015f;
    [SerializeField] private GameObject toothbrushText;
    [SerializeField] private string displayText;
    [SerializeField] private MeshRenderer[] rends;
    
    private bool hasBrushedTeeth;
    private ColorAdjustments colorAdjustments;
    private float exposureValue;
    
    private void Start()
    {
        EventSystem<int>.Subscribe(EventType.TASK_NUMBER, ActivateToothBrush);
        volume.profile.TryGet(out colorAdjustments);
    }
    
    public void Interact()
    {
        if (!hasBrushedTeeth)
        {
            gameObject.layer = 0;
            EventSystem.RaiseEvent(EventType.NEXT_TASK);
            StartCoroutine("BrushingTeeth");
            EventSystem<float>.RaiseEvent(EventType.CHANGE_PLAYER_SPEED, 3f);
            hasBrushedTeeth = true;
        }
    }

    private void ActivateToothBrush(int taskNumber)
    {
        if (taskNumber == 4)
        {
            GetComponent<BoxCollider>().enabled = true;
            foreach (MeshRenderer rend in rends)
            {
                rend.enabled = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (hasBrushedTeeth)
        {
            exposureValue -= darkeningSpeed;
            colorAdjustments.postExposure.value = exposureValue;
            if (colorAdjustments.postExposure.value <= -2.25f)
            {
                hasBrushedTeeth = false;
            }
        }
    }

    public string DisplayText()
    {
        return displayText;
    }

    private IEnumerator BrushingTeeth()
    {
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1f);
        GetComponent<AudioSource>().Stop();
        
        EventSystem.RaiseEvent(EventType.NEXT_TASK);
        
        toothbrushText.SetActive(true);
        yield return new WaitForSeconds(3f);
        toothbrushText.SetActive(false);
        
        foreach (MeshRenderer rend in rends)
        {
            rend.enabled = false;
        }
    }
}
