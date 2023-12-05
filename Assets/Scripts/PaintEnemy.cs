using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaintEnemy : MonoBehaviour
{
    public Color32 color;
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

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        color = gameObject.GetComponent<Image>().color;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Hitting");
        if (collision.gameObject.CompareTag("Player"))
        {
            damageCount--;
            color = new Color32(250,0,0,100);
            if (damageCount <= 0)
            {
                Destroy(player);
                Destroy(drawings);
                Destroy(gameObject);
            }
        }
        else
        {
            color = new Color32(255,255,255, 100);
        }
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
