using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugAlterMove : MonoBehaviour
{
    public Transform[] wayPoints;
    Transform destination;
    public float speed;

    public float rotatingSpeed;
    public float rotationModifier;

    private void Start()
    {
        ChangeDestination();
    }

    private void Update()
    {
        if(Vector3.Distance(transform.position, destination.position) > 0.5f)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination.position, speed * Time.deltaTime);
        }
        else
        {
            ChangeDestination();
        }
    }

    private void FixedUpdate()
    {
        if (destination != null)
        {
            LookTarget();
        }
    }

    void Move(Vector3 _destination)
    {
        this.destination.position = _destination;
    }

    void ChangeDestination()
    {
        int randomWayPoint = Random.Range(0, wayPoints.Length);
        destination = wayPoints[randomWayPoint];

        Move(destination.position);
    }

    void LookTarget()
    {
        Vector3 direction = destination.position - gameObject.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - rotationModifier;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotatingSpeed);

    }
}
