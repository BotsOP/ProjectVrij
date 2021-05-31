using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpookHappening : MonoBehaviour
{
    public GameObject spook;
    public Animator spookAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter()
    {
        spookAnimator.SetBool("IsActive", true);
    }
}
