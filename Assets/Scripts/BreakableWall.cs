using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWall : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        var x = other.GetComponent<PlayerMovement>();
        if (x)
        {
            if (Input.GetMouseButton(0)){
                this.gameObject.SetActive(false);
            }
        }
    }
}
