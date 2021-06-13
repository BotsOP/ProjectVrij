using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toothbrush : MonoBehaviour, IInteractable
{
    public GameObject toothbrushText;
    public string _displayText;
    public Animator GoblinAnimator;
    public void Interact()
    {
        gameObject.layer = 0;
        Destroy(gameObject, 4.1f);
        GoblinAnimator.SetBool("IsActive", true);
        StartCoroutine("BrushingTeeth");
    }
    public string displayText()
    {
        return _displayText;
    }

    private IEnumerator BrushingTeeth()
    {
        Debug.Log("test");
        yield return new WaitForSeconds(1f);
        Debug.Log("test2");
        toothbrushText.SetActive(true);
        yield return new WaitForSeconds(3f);
        toothbrushText.SetActive(false);
    }
}
