using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fridge : MonoBehaviour, IInteractable
{
    public string _displayText;
    public Animator PlayerAnimator;
    public GameObject Hamburger;
    public void Interact()
    {
        Hamburger.SetActive(true);
        PlayerAnimator.SetBool("IsActive", true);
        FindObjectOfType<ToDoList>().NextTask();
        gameObject.layer = 0;
        Destroy(this);
    }
    public string displayText()
    {
        return _displayText;
    }
}
