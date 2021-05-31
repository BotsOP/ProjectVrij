using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRaycastAnim : MonoBehaviour, IInteractable
{
    public Animator animator;
    private bool isNotMoving;
    private bool open;

    public void Interact()
    {
        open = !open;
        animator.SetBool("DoorOpen", open);
    }
}
