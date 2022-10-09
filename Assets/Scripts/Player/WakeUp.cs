using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class WakeUp : MonoBehaviour
{
    [SerializeField] private Volume volume;
    [SerializeField] private GameObject player;
    [SerializeField] private Transform spawnpoint;
    private Vignette vignette;
    private float vigValue = 0.8f;
    private bool doneWakingUp;
    private void Start()
    {
        volume.profile.TryGet<Vignette>(out vignette);
    }

    private void FixedUpdate()
    {
        if(doneWakingUp)
        {
            return;
        }
            

        if(vigValue <= 0.2f && !doneWakingUp)
        {
            GameObject _player = Instantiate(player, spawnpoint.position, Quaternion.Euler(0, 231, 0));
            transform.SetParent(_player.transform);
            transform.localPosition = new Vector3(0, 0.8f, 0);
            doneWakingUp = true;
            _player.GetComponent<PlayerLook>().playerCamera = transform;
        }

        vigValue -= 0.003f;
        vignette.intensity.value = vigValue;
        
    }
}
