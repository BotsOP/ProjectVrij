using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Transform playerCamera;
    [SerializeField] private float mouseSensitivity = 3.5f;
    private float cameraPitch = 0;

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
        
        cameraPitch -= targetMouseDelta.y * mouseSensitivity;
        cameraPitch = Mathf.Clamp(cameraPitch, -90, 90);
        playerCamera.localEulerAngles = Vector3.right * cameraPitch;

        transform.Rotate(Vector3.up * (targetMouseDelta.x * mouseSensitivity));
    }
}
