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
    public AudioSource creepySound;
    public Animator GoblinAnimator;
    private bool hasBrushedTeeth;
    private ColorAdjustments colorAdjustments;
    private float exposureValue;
    private PlayerMove player;
    
    void Start()
    {
        volume.profile.TryGet<ColorAdjustments>(out colorAdjustments);
        player = FindObjectOfType<PlayerMove>();
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
        if (hasBrushedTeeth)
        {
            exposureValue -= darkeningSpeed;
            colorAdjustments.postExposure.value = exposureValue;
            if (colorAdjustments.postExposure.value <= -2.25f)
            {
                hasBrushedTeeth = false;
            }
        }
        if (player.speed >= 3 && hasBrushedTeeth)
        {
            player.speed -= 0.03f;
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
        creepySound.Play();
        yield return new WaitForSeconds(3f);
        toothbrushText.SetActive(false);
        transform.GetChild(0).gameObject.SetActive(false);
        transform.GetChild(1).gameObject.SetActive(false);
    }
}
