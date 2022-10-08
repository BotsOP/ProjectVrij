using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] float speed = 6;
    [SerializeField] float gravity = -13;
    [SerializeField] private AudioClip[] footSteps;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private float timeBetweenFootSteps;
    public bool stepping;
    private GameObject pauseMenu;
    [HideInInspector] public bool pauseMenuOn;
    float velocityY;

    private void Start()
    {
        EventSystem<float>.Subscribe(EventType.CHANGE_PLAYER_SPEED, SetSpeed);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMenu == null)
                pauseMenu = FindObjectOfType<MenuManager>().transform.GetChild(0).gameObject;

            if (pauseMenuOn)
            {
                pauseMenu.SetActive(false);
                pauseMenuOn = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                pauseMenu.SetActive(true);
                pauseMenuOn = true;
                Cursor.lockState = CursorLockMode.None;
            }
        }

        if (pauseMenuOn)
            return;
        
        HandleMovement();
    }

    void HandleMovement() {
        Vector2 targetDir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
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

