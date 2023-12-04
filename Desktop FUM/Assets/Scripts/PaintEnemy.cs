using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintEnemy : MonoBehaviour
{
    public float minWidth;
    public float maxWidth;
    public float minHeight;
    public float maxHeight;

    public Transform parent;
    public GameObject dirt; 
    public float speed = 20;
    Rigidbody2D rb;
    public Vector3 destination;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        StartCoroutine(ChangeDestination());    
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {      
        Vector3 direction = (destination - gameObject.transform.position).normalized;
        rb.velocity = direction * speed;
    }

    IEnumerator ChangeDestination()
    {
        //put animation here
        yield return new WaitForSeconds(3);
        while(true)
        {
            yield return new WaitForSeconds(2);
            destination = new Vector3(Random.Range(minWidth, maxWidth), Random.Range(minHeight, maxHeight), 0);

            Instantiate(dirt, gameObject.transform.position, Quaternion.identity,parent);
        }
    }
}
