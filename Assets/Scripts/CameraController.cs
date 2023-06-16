using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject cameraPos;
    public Vector3 minPos, maxPos;
    Vector3 moveInput;

    public Transform target;

    private TransparentWall currentTransparentWall;



    private void FixedUpdate()
    {
        //transform.position = new Vector3(target.position.x, 22f, target.position.z -12f);
        transform.position = new Vector3(Mathf.Clamp(target.position.x, minPos.x, maxPos.x), 22f, Mathf.Clamp(target.position.z -12f, minPos.z, maxPos.z));
        CheckPlayerBehindWall();
    }

    private void CheckPlayerBehindWall()
    {
        Vector3 direction = target.position - transform.position;
        //Calculate the length
        float length = Vector3.Distance(target.position, transform.position);
        //Draw the ray in the debug
        Debug.DrawRay(transform.position, direction.normalized * length, Color.red);

        RaycastHit currentHit;
        //Cast the ray and report the firt object hit filtering by "Wall" layer mask
        if (Physics.Raycast(transform.position, direction, out currentHit, length, LayerMask.GetMask("Wall")))
        {
            //Getting the script to change transparency of the hit object
            TransparentWall transparentWall = currentHit.transform.GetComponent<TransparentWall>();
            //If the object is not null
            if (transparentWall)
            {
                //If there is a previous wall hit and it's different from this one
                if (currentTransparentWall && currentTransparentWall.gameObject != transparentWall.gameObject)
                {
                    //Restore its transparency setting it not transparent
                    currentTransparentWall.ChangeTransparency(false);
                }
                //Change the object transparency in transparent.
                transparentWall.ChangeTransparency(true);
                currentTransparentWall = transparentWall;
            }
        }
        else
        {
            //If nothing is hit and there is a previous object hit
            if (currentTransparentWall)
            {
                //Restore its transparency setting it not transparent
                currentTransparentWall.ChangeTransparency(false);
            }
        }
    }


    #region "Deprecated"
    private void Move(float xAxis, float zAxis)
    {
        //var dir = (transform.right * xAxis + transform.forward * zAxis).normalized;
         moveInput = new Vector3(xAxis, 0f, zAxis).normalized;
        //_myRB.MovePosition(transform.position + dir * _movSpeed * Time.fixedDeltaTime);
        transform.position += moveInput * Time.fixedDeltaTime * 15f;

    }
    #endregion
   
}
