using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GremlinWall : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private AudioSource audiSource;
    private void Start()
    {
        EventSystem.Subscribe(EventType.ENTER_LIVINGROOM, ActiveGremlin);
    }

    private void ActiveGremlin()
    {
        anim.SetBool("IsActive", true);
        audiSource.enabled = false;
    }
}
