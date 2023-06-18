using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doors : MonoBehaviour
{
    [SerializeField] bool _locked;

    public bool locked { get { return _locked; } }
    public DoorType type;
                     

    public void OpenDoor()
    {
        if (!_locked) { gameObject.SetActive(false); Debug.LogError("Door opened"); }
        else if (type == DoorType.KeyDoor) Debug.LogError("Door Locked needs key");
        else if (type == DoorType.SwitchDoor) Debug.LogError("Door Locked, find the switch to unlock");
    }

    public void UnlockDoor()
    {
        _locked = false;
        Debug.LogError("Unlocked!");
    }

    public void LockDoor()
    {
        _locked = true;
    }
}

public enum DoorType
{
    Unlocked,
    KeyDoor,
    SwitchDoor
}
