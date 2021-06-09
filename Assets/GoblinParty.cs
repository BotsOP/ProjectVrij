using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinParty : MonoBehaviour
{
    public GameObject Goblins;
    public Animator GoblinAnimator;

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
        GoblinAnimator.SetBool("IsActive", true);
    }
}
