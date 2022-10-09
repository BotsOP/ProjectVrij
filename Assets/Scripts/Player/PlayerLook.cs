using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 3.5f;
    public Transform playerCamera;
    private float cameraPitch = 0;
    private Vector2 currentMouseDelta;
    private Vector2 currentmouseDeltaVelocity;

    private void Start() {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        if (!MenuManager.Instance.pauseMenuOn)
        {
            MouseLook();
        }
    }

    private void MouseLook() {
        Vector2 targetMouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        currentMouseDelta = targetMouseDelta;
        
        cameraPitch -= currentMouseDelta.y * mouseSensitivity;
        cameraPitch = Mathf.Clamp(cameraPitch, -90, 90);
        playerCamera.localEulerAngles = Vector3.right * cameraPitch;

        transform.Rotate(Vector3.up * (currentMouseDelta.x * mouseSensitivity));
    }
}
