using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DownloadManager : MonoBehaviour
{
    public static event System.Action DownloadWindowClosed;
    public GameObject[] documents;

    [Header("Timer")]
    public Timer timer;
    public GameManager gameManager;
    public bool isWindowOpened;
    public GameObject downloadWindow;

    [Header("Points")]
    public Transform minWidth;
    public Transform maxWidth;
    public Transform minSpawnPoint;
    public Transform maxSpawnPoint;

    [Header("Text Control")]
    public TMP_Text title;
    public TMP_Text status;
    public TMP_Text contentUp;
    public TMP_Text contentDown;
    public TMP_Text timerMessege;

    [Header("Spawing and Collecting")]
    public bool isSpawning;
    public int collected;
    public int failed;

    [Header("Slider Control")]
    public Slider slider;

    [Header("Others")]
    public Button downloadButton;
    public Transform myCanvas;
    public IELauncher ieLauncher;

    private void Start()
    {
        slider.value = 0;
        downloadButton.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isWindowOpened && downloadWindow.activeSelf == true)
        {
            isWindowOpened = true;
            spawnDocuments();
        }

        if (isSpawning)
        {
            timerMessege.text = "You have  " + timer.currentTime.ToString() + "  seconds";
        }

        if(timer.currentTime == 0 && slider.value != 20)
        {
            gameManager.FailedGame();
        }
    }

    public void addProgress()
    {
        slider.value ++;

        if(slider.value >= 20)
        {
            slider.value = 20;
            endGame();
        }
    }

    public void FailedProgress()
    {
        slider.value--;

        if(slider.value <= 0)
        {
            slider.value = 0;
        }
    }

    public void WindowClosedEvent()
    {
        isSpawning = false;
        DownloadWindowClosed?.Invoke();
    }

    public void endGame()
    {
        isSpawning = false;
        ieLauncher.isDownloaded = true;
        slider.value = 20;
        downloadButton.interactable = true;
        timer.isCounting = false;
        Debug.Log("endGame");
        title.text = "Download Complete";
        status.text = "Download Complete";
        contentUp.text = "Saved:\nWindows_Update.exe from google.com";
        contentDown.text = "Downloaded: 100GB in sec\nDownloaded to C:/User/Downloads\nTransfer rate: 128 Kb/sec";
        timerMessege.text = "times Up!";
    }

    public void spawnDocuments()
    {
        isSpawning = true;
        
        StartCoroutine(spawnFile());
        title.text = "Use WASD to catch files";
        status.text = "Downloading Updates...";
        contentUp.text = "Saving:\nWindows_Update.exe from google.com";
        contentDown.text = "Downloading:2GB in sec\nDownloading to C:/User/Downloads\nTransfer rate: 128 Kb/sec";
    }

    IEnumerator spawnFile()
    {
        yield return new WaitForSeconds(2);

        while(isSpawning)
        {
            timer.isCounting = true;
            yield return new WaitForSeconds(0.5f);
            if(!isSpawning)
                break;

            Vector3 spawnPoint = new Vector3(Random.Range(minSpawnPoint.position.x, maxSpawnPoint.position.x), minSpawnPoint.position.y, 0);
            Instantiate(documents[Random.Range(0,3)], spawnPoint, Quaternion.identity, myCanvas);
        }
    }
}
