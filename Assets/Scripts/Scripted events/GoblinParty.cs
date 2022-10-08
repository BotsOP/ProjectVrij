using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinParty : MonoBehaviour
{
    public Animator GoblinAnimator;

    void Start()
    {
        EventSystem<int>.Subscribe(EventType.TASK_NUMBER, ActivateGoblinParty);
    }

    private void ActivateGoblinParty(int taskNumber)
    {
        if (taskNumber == 5)
        {
            GoblinAnimator.SetBool("IsActive", true);
        }
    }
}
