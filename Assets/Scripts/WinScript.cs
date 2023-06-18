using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour
{
    //BORRAR POST ENTREGA NIVELES\
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) { Debug.LogError("You Win this demo!"); }
    }
}
