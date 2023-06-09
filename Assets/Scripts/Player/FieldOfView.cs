using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float range;
    public float angle;

    public bool seesEnemy;

    private LayerMask targetMask;
    private LayerMask obstructionMask;
    GunController gun;

    private void Start()
    {
        gun = GetComponent<GunController>();
        range = gun.weaponRange;
        targetMask = gun.layerMask;
        obstructionMask = gun.obstructionMask;
    }

    public Enemy FieldOfViewCheck()
    {
        Collider[] RangeChecks = Physics.OverlapSphere(transform.position, range, targetMask);
        if (RangeChecks.Length != 0)
        {
            Transform Target = RangeChecks[0].transform;
            Vector3 directionToTarget = (Target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, Target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                {

                    seesEnemy = true; 
                    return Target.GetComponent<Enemy>();
                }

                else
                    seesEnemy = false; return null;
            }
            else
                seesEnemy = false; return null;
        }
        else if (seesEnemy)
            seesEnemy = false; return null;

    }

    private void OnDrawGizmos()
    {
        Vector3 viewAngleA = DirectionFromAngle(transform.eulerAngles.y, -angle / 2);
        Vector3 viewAngleB = DirectionFromAngle(transform.eulerAngles.y, angle / 2);
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + viewAngleA * range);
        Gizmos.DrawLine(transform.position, transform.position + viewAngleB * range);
        
    }

    private Vector3 DirectionFromAngle(float eulerY, float angleInDegrees)
    {
        angleInDegrees += eulerY;

        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}
