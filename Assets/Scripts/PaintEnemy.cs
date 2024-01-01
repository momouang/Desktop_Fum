using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaintEnemy : MonoBehaviour
{
    public RectTransform minWidth;
    public RectTransform maxWidth;
    public RectTransform minHeight;
    public RectTransform maxHeight;

    public float damageCount = 3f;
    public GameObject player;
    public GameObject drawings;

    public Transform parent;
    public GameObject dirt; 
    public float speed = 20;
    Rigidbody2D rb;
    public Vector3 destination;

    public DrawMesh drawMesh;
    public ParticleSystem smallBomb;


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        StartCoroutine(ChangeDestination());    
    }

    void Update()
    {
        Move();
    }

    void Move()
    {      
        Vector3 direction = (destination - gameObject.transform.position).normalized;
        rb.velocity = direction * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Instantiate(smallBomb, collision.ClosestPoint(collision.transform.position), Quaternion.identity);
            smallBomb.Play();
            damageCount--;
            GetComponent<Image>().color = Color.red;
            if (damageCount <= 0)
            {
                drawMesh.endGame = true;
                Destroy(player);
                Destroy(drawings);
                Destroy(gameObject);
            }
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        GetComponent<Image>().color = Color.white;
    }

    IEnumerator ChangeDestination()
    {
        //put animation here
        yield return new WaitForSeconds(3);
        while(true)
        {
            yield return new WaitForSeconds(2);
            destination = new Vector3(Random.Range(minWidth.position.x, maxWidth.position.x), Random.Range(minHeight.position.y, maxHeight.position.y), 0);

            Instantiate(dirt, gameObject.transform.position, Quaternion.identity,parent);
        }
    }
}
