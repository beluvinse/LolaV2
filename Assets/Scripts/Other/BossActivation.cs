using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossActivation : MonoBehaviour
{
    [SerializeField] Doors Door;

    private void OnTriggerEnter(Collider other)
    {

        var x = other.GetComponent<ShaderZombies>();
        if (x)
        {
            Debug.LogError("Boss Zombie Inbound");
            x.SetShaderRange(15f);
            Door.gameObject.SetActive(true);
            Door.LockDoor();
        }
        
        
    }
}
