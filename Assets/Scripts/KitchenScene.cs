using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenScene : MonoBehaviour
{
    public GameObject Player;
    public Animator PlayerAnimator;
    public GameObject Hamburger;

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
        Hamburger.SetActive(true);
        PlayerAnimator.SetBool("IsActive", true);
    }
}
