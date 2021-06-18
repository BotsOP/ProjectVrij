using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] float speed = 6;
    [SerializeField] float gravity = -13;
    [SerializeField] private AudioClip[] footSteps;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private float timeBetweenFootSteps;
    public bool stepping;
    float velocityY;

    void Update() {
        HandleMovement();
    }

    void HandleMovement() {
        Vector2 targetDir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (targetDir.x != 0 && !stepping || targetDir.y != 0 && !stepping)
        {
            Debug.Log("step");
            StartCoroutine("FootSteps");
        }

        if(controller.isGrounded) {
            velocityY = 0;
        }

        velocityY += gravity * Time.deltaTime;

        Vector3 movement = (transform.forward * targetDir.y + transform.right * targetDir.x) * speed + Vector3.up * velocityY;
        controller.Move(movement * Time.deltaTime);
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

