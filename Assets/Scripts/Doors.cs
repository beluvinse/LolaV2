using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    [SerializeField] bool _locked;

    public bool loocked { get { return _locked; } }

    public void OpenDoor()
    {
        if (!_locked) { gameObject.SetActive(false); Debug.Log("Door opened"); }
        else { Debug.Log("Door Locked, need key"); }
    }

    public void UnlockDoor()
    {
        _locked = false;
        Debug.Log("Desabrido");
    }
}
