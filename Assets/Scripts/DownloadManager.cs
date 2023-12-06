using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DownloadManager : MonoBehaviour
{
    public GameObject[] documents;

    public Transform minWidth;
    public Transform maxWidth;
    public Transform minSpawnPoint;
    public Transform maxSpawnPoint;

    public float speed;
    public bool isSpawning;
    public int collected;

    public Slider slider;
    public bool addPoints = false;
    public bool isEnded = false;

    public Transform myCanvas;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            spawnDocuments();     
        }

        if(addPoints)
        {
            addProgress();
        }

        if(slider.value == 20)
        {
            isEnded = true;
            endGame();
        }
    }

    public void addProgress()
    {
        slider.value ++;

        if(slider.value == 20)
        {
            slider.value = 20;
        }
    }

    void endGame()
    {
        Debug.Log("endGame");
    }

    public void spawnDocuments()
    {
        isSpawning = true;
        StartCoroutine(spawnFile());
    }

    IEnumerator spawnFile()
    {
        while(isSpawning)
        {
            yield return new WaitForSeconds(1);
            Vector3 spawnPoint = new Vector3(Random.Range(minSpawnPoint.position.x, maxSpawnPoint.position.x), minSpawnPoint.position.y, 0);
            Instantiate(documents[0], spawnPoint, Quaternion.identity, myCanvas);
        }
    }
}
