using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private float speed = 6;
    [SerializeField] private float gravity = -13;
    [SerializeField] private AudioClip[] footSteps;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private float timeBetweenFootSteps;
    [SerializeField] private bool stepping;
    private float velocityY;

    private void Start()
    {
        EventSystem<float>.Subscribe(EventType.CHANGE_PLAYER_SPEED, SetSpeed);
    }

    private void Update() {
        if (!MenuManager.Instance.pauseMenuOn)
        {
            HandleMovement();
        }
    }

    private void HandleMovement()
    {
        float horizontal = 0;
        float vertical = 0;
        if (Input.GetKey(InputManager.Instance.forwardKey))
        {
            vertical += 1;
        }
        if (Input.GetKey(InputManager.Instance.leftKey))
        {
            horizontal -= 1;
        }
        if (Input.GetKey(InputManager.Instance.rightKey))
        {
            horizontal += 1;
        }
        if (Input.GetKey(InputManager.Instance.backwardsKey))
        {
            vertical -= 1;
        }
        
        Vector2 targetDir = new Vector2(horizontal, vertical);
        if (targetDir.x != 0 && !stepping || targetDir.y != 0 && !stepping)
        {
            StartCoroutine("FootSteps");
        }

        if(controller.isGrounded) {
            velocityY = 0;
        }

        velocityY += gravity * Time.deltaTime;

        Vector3 movement = (transform.forward * targetDir.y + transform.right * targetDir.x) * speed + Vector3.up * velocityY;
        controller.Move(movement * Time.deltaTime);
    }

    private void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }

    private IEnumerator FootSteps()
    {
        stepping = true;
        AudioClip randomFootStep = footSteps[Random.Range(0, footSteps.Length)];
        audioSource.PlayOneShot(randomFootStep);
        yield return new WaitForSeconds(randomFootStep.length);
        yield return new WaitForSeconds(timeBetweenFootSteps);
        stepping = false;
    }
}

