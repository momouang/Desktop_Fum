using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugScript : MonoBehaviour
{
    public RectTransform destination;
    public float speed;
    public float rotatingSpeed;
    Rigidbody2D rb;

    public float rotationModifier;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        Move();
    }

    private void FixedUpdate()
    {
        if(destination != null)
        {
            LookTarget();
        }
    }

    public void Move()
    {
        Vector3 direction = (destination.position - gameObject.transform.position).normalized;
        rb.velocity = direction * speed;   
    }

    void LookTarget()
    {
        Vector3 direction = destination.position - gameObject.transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - rotationModifier;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotatingSpeed);

        if(direction.magnitude <= 0.5)
        {
            gameObject.SetActive(false);
        }
    }
}
