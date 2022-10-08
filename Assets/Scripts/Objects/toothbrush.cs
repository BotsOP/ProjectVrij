using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class toothbrush : MonoBehaviour, IInteractable
{
    public Volume volume;
    public float darkeningSpeed = 0.015f;
    public GameObject toothbrushText;
    public string _displayText;
    public Animator GoblinAnimator;
    [SerializeField] private MeshRenderer[] rends;
    
    private bool hasBrushedTeeth;
    private ColorAdjustments colorAdjustments;
    private float exposureValue;
    private PlayerMove player;
    
    void Start()
    {
        EventSystem<int>.Subscribe(EventType.TASK_NUMBER, ActivateToothBrush);
        volume.profile.TryGet<ColorAdjustments>(out colorAdjustments);
    }
    
    public void Interact()
    {
        if (!hasBrushedTeeth)
        {
            player = FindObjectOfType<PlayerMove>();
            gameObject.layer = 0;
            GoblinAnimator.SetBool("IsActive", true);
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
