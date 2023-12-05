using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintPlayer : MonoBehaviour
{
    public float speed = 1f;
    public Transform minHeight;
    public Transform maxHeight;
    public Transform minWidth;
    public Transform maxWidth;

    Rigidbody2D rb;

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 currentPosition = gameObject.transform.position;
        Vector3 targetPosition = currentPosition + new Vector3 (Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"),0) * speed;
        targetPosition.x = Mathf.Clamp(targetPosition.x,minWidth.position.x,maxWidth.position.x);
        targetPosition.y = Mathf.Clamp(targetPosition.y, minHeight.position.y, maxHeight.position.y);
        gameObject.transform.position = targetPosition;

        //Debug.Log(targetPosition);
    }


}
