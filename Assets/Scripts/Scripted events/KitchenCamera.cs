using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenCamera : MonoBehaviour
{
    [SerializeField] private Animator anim;
    private void Start()
    {
        EventSystem<int>.Subscribe(EventType.TASK_NUMBER, KitchenCutscne);
    }
    
    private void KitchenCutscne(int taskNumber)
    {
        if (taskNumber == 1)
        {
            GetComponent<Camera>().enabled = true;
            anim.SetBool("IsActive", true);
        }
    }
}
