using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintPlayer : MonoBehaviour
{
    public float speed = 1f;
    public float damageCount = 3;
    public GameObject enemy;
    public GameObject dirtGroup;
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
        targetPosition.x = Mathf.Clamp(targetPosition.x,-3.31f,4.41f);
        targetPosition.y = Mathf.Clamp(targetPosition.y, -1.70f, 1.66f);
        gameObject.transform.position = targetPosition;

        Debug.Log(targetPosition);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Hitting");
        if(collision.gameObject.CompareTag("Enemy"))
        {
            damageCount--;
            if(damageCount <= 0)
            {
                Destroy(enemy);
                Destroy(dirtGroup);
            }
        }
    }
}
