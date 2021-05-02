using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] float speed = 6;
    [SerializeField] float gravity = -13;
    float velocityY;

    void Update() {
        HandleMovement();
    }

    void HandleMovement() {
        Vector2 targetDir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if(controller.isGrounded) {
            velocityY = 0;
        }

        velocityY += gravity * Time.deltaTime;

        Vector3 movement = (transform.forward * targetDir.y + transform.right * targetDir.x) * speed + Vector3.up * velocityY;
        controller.Move(movement * Time.deltaTime);
    }
}

