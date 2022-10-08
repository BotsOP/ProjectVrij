using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] float mouseSensitivity = 3.5f;
    public Transform playerCamera;
    float cameraPitch = 0;
    Vector2 currentMouseDelta;
    Vector2 currentmouseDeltaVelocity;
    public bool wokeUp;
    private PlayerMove player;

    void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        player = GetComponent<PlayerMove>();
    }

    void Update()
    {
        if (player.pauseMenuOn)
            return;
        
        if(wokeUp)
            MouseLook();
    }

    void MouseLook() {
        Vector2 targetMouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        //currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta, targetMouseDelta, ref currentmouseDeltaVelocity, mouseSmoothTime);
        currentMouseDelta = targetMouseDelta;
        
        cameraPitch -= currentMouseDelta.y * mouseSensitivity;
        cameraPitch = Mathf.Clamp(cameraPitch, -90, 90);
        playerCamera.localEulerAngles = Vector3.right * cameraPitch;

        transform.Rotate(Vector3.up * currentMouseDelta.x * mouseSensitivity);
    }
}
