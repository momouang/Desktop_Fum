using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownloadingPlayer : MonoBehaviour
{
    public DownloadManager downloadManager;

    public float speed = 1f;
    public Transform minWidth;
    public Transform maxWidth;

    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        Move();

        if(downloadManager.collected == 1)
        {
            anim.SetTrigger("Catched");
        }
    }

    void Move()
    {
        Vector2 currentPosition = gameObject.transform.position;
        Vector2 targetPosition = currentPosition + new Vector2(Input.GetAxis("Horizontal"),0) * speed;
        targetPosition.x = Mathf.Clamp(targetPosition.x, minWidth.position.x, maxWidth.position.x);

        gameObject.transform.position = targetPosition;

        //Debug.Log(targetPosition);
    }
}
