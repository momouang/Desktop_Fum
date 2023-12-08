using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Documents : MonoBehaviour
{
    public Transform destroyPoint;
    public DownloadManager downloadManager;

    private void Start()
    {
        destroyPoint = GameObject.FindGameObjectWithTag("Destroy Point").transform;
        downloadManager = GameObject.FindObjectOfType<DownloadManager>();
    }


    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.y <= destroyPoint.position.y)
        {
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            downloadManager.addProgress();
            downloadManager.collected++;
            Destroy(gameObject);
        }
    }
}
