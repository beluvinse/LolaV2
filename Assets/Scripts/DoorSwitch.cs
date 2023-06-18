using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSwitch : MonoBehaviour
{
    public Doors door;

    public bool onOff;

    private void Start()
    {
        door.type = DoorType.SwitchDoor;
        onOff = true;
    }

    /*private void Update()
    {
        if(onOff == true)
        {
            door.LockDoor();
        }
        else
        {
            door.UnlockDoor();
        }*/

    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<PlayerMovement>();
        if (player)
        {
            Debug.LogError("Press E to interact;");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        var player = other.GetComponent<PlayerMovement>();
        if (player)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                onOff = false;
                door.UnlockDoor();
            }
        }
        
    }
}
