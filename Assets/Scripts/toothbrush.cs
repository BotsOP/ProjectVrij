using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toothbrush : MonoBehaviour, IInteractable
{
    public GameObject toothbrushText;
    public string _displayText;
    public Animator GoblinAnimator;
    private bool hasBrushedTeeth;
    public void Interact()
    {
        if (!hasBrushedTeeth)
        {
            gameObject.layer = 0;
            Destroy(gameObject, 4.1f);
            GoblinAnimator.SetBool("IsActive", true);
            FindObjectOfType<ToDoList>().NextTask();
            StartCoroutine("BrushingTeeth");
            hasBrushedTeeth = true;
        }
    }
    public string displayText()
    {
        return _displayText;
    }

    private IEnumerator BrushingTeeth()
    {
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(1f);
        GetComponent<AudioSource>().Stop();
        FindObjectOfType<ToDoList>().NextTask();
        toothbrushText.SetActive(true);
        yield return new WaitForSeconds(3f);
        toothbrushText.SetActive(false);
    }
}
