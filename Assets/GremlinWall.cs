using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GremlinWall : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private AudioSource audiSource;
    void Start()
    {
        EventSystem.Subscribe(EventType.ENTER_LIVINGROOM, ActiveGremlin);
    }

    void ActiveGremlin()
    {
        anim.SetBool("IsActive", true);
        audiSource.enabled = false;
    }
}
