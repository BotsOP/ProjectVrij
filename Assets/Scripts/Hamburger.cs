using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hamburger : MonoBehaviour, IInteractable
{
    public string _displayText;
    public AudioSource radio1;
    public AudioSource radio2;
    public void Interact()
    {
        radio1.Stop();
        radio2.Play();
        Destroy(gameObject);
    }
    public string displayText()
    {
        return _displayText;
    }
}
