using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class DynamicDOF : MonoBehaviour
{
    public Volume volume;
    public float focusSpeed;
    DepthOfField dof;
    float distance;
    void Start()
    {
        volume.profile.TryGet<DepthOfField>(out dof);
    }

    void Update()
    {
        RaycastHit hit;
        Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out hit)) {
            //Transform objectHit = hit.transform;
            distance = Vector3.Distance(transform.position, hit.point);
        }

        dof.focusDistance.value = Mathf.Lerp(dof.focusDistance.value, distance, Time.deltaTime * focusSpeed);
    }
}
