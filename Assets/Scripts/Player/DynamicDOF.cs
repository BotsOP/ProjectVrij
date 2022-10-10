using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class DynamicDOF : MonoBehaviour
{
    [SerializeField] private Volume volume;
    [SerializeField] private float focusSpeed;
    private DepthOfField dof;
    private float distance;
    private void Start()
    {
        volume.profile.TryGet(out dof);
    }

    private void Update()
    {
        RaycastHit hit;
        Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out hit)) {
            distance = Vector3.Distance(transform.position, hit.point);
        }

        dof.focusDistance.value = Mathf.Lerp(dof.focusDistance.value, distance, Time.deltaTime * focusSpeed);
    }
}
