using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    [SerializeField] float _doorRange;

    public GameObject key;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 3))
            {
                var door = hit.collider.GetComponent<Doors>();

                if (door)
                {
                    door.OpenDoor();
                    if (!door.locked)
                    {
                        Debug.Log("abrido");
                        
                    }
                    else if (key)
                    {
                        door.UnlockDoor();
                    }
                }
            }
        }
        
    }
}
