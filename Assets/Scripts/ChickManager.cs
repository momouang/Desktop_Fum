using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickManager : MonoBehaviour
{
    [Header("Menu Opening")]
    public Animator startMenuAnim;
    public bool firstTimetoDrop = false;
    public bool isOpened = false;
    public bool chickedDropped = false;

    [Header("Chick System")]
    Vector3 _destination;
    public float speed;
    public Transform[] wayPoints;
    public float petMoveTimer, originalPetMoveTimer;
    public bool facingRight = true;

    GameObject tempCrump;
    public GameObject crump;
    public Transform spawnPoint;
    public Transform parent;

    public bool isFeeding = false;

    Transform crumpPosition;


    private void Start()
    {
        gameObject.GetComponent<Rigidbody2D>().simulated = false;
        petMoveTimer = originalPetMoveTimer;
    }

    private void Update()
    {

        if (firstTimetoDrop && chickedDropped)
        {
            if (isFeeding && tempCrump == null)
            {
                isFeeding = false;
            }

            //------------------------MOVE-------------------------
            if (petMoveTimer > 0)
            {
                petMoveTimer -= Time.deltaTime;
            }
            else
            {
                MoveRandomWaypoints();
                petMoveTimer = originalPetMoveTimer;
            }

            if (Vector3.Distance(transform.position, _destination) > 0.5f)
            {
                transform.position = Vector3.MoveTowards(transform.position, _destination, speed * Time.deltaTime);
            }

            //-----------------------FLIP--------------------------
            if((transform.position.x- _destination.x) > 0 && facingRight)
            {
                Flip(-180);
            }

            if((transform.position.x - _destination.x) < 0 && !facingRight)
            {
                Flip(0);
            }
        }

        crump.GetComponent<Rigidbody2D>().AddForce(-transform.right * 10);
    }

    public void StartMenu()
    {
        if(!firstTimetoDrop)
        {
            StartCoroutine(ChickDrop());
            firstTimetoDrop = true;
        }

        if (!isOpened)
        {
            OpenStartWindow();
        }
        else
        {
            CloseStartWindow();
        }
    }

    public virtual void OpenStartWindow()
    {
        startMenuAnim.SetBool("isOpened", true);
        isOpened = true;
    }

    public virtual void CloseStartWindow()
    {
        startMenuAnim.SetBool("isOpened", false);
        isOpened = false;
    }

    IEnumerator ChickDrop()
    {
        yield return new WaitForSeconds(2);
        gameObject.GetComponent<Rigidbody2D>().simulated = true;
        chickedDropped = true;
        FindObjectOfType<AudioManager>().Play("Chick Sound");
    }

    private void Move(Vector3 _destination)
    {
        this._destination = _destination;
    }

    private void MoveRandomWaypoints()
    {
        if(!isFeeding)
        {
            int randomWayPoint = Random.Range(0, wayPoints.Length);
            Move(wayPoints[randomWayPoint].position);
        }
        else
        {
            Move(crumpPosition.position);
        }
    }

    void Flip(int d)
    {
        Quaternion currentScale = Quaternion.Euler(0, d, 0);
        transform.rotation = currentScale;
        facingRight = !facingRight;
    }

    public void Feed()
    {
        if (isFeeding) return;

        isFeeding = true;
        FindObjectOfType<AudioManager>().Play("Feed Sound");
        tempCrump = Instantiate(crump, spawnPoint.position, Quaternion.identity, parent);
        tempCrump.GetComponent<Rigidbody2D>().AddForce(-transform.right * 8);

        crumpPosition = tempCrump.transform;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Crump"))
        {
            FindObjectOfType<AudioManager>().Play("Chick Sound");
            Destroy(collision.gameObject);
        }
    }



}
