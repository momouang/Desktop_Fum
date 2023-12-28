using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ErrorManager : MonoBehaviour
{
    [SerializeField]
    public Timer timer;
    public float targetTime;
    public GameManager gameManager;
    public bool isCompleted = false;
    public bool isFailed = false;

    [SerializeField]
    public float minWidth;
    public float maxWidth;
    public float minHeight;
    public float maxHeight;
    public float minDepth = 0;

    public Transform parentCanvas;
    public float spawnTimer = 0.5f;
    public bool isSpawn = false;

    public Image[] errorWindow;

    public float count;
    public float closeCount;

    public NotePadManager notepadManager;

    private void OnEnable()
    {
        ErrorWindowClose.ErrorWindowCloseEvent += OnErrorWindowClose;
    }

    private void OnDisable()
    {
        ErrorWindowClose.ErrorWindowCloseEvent -= OnErrorWindowClose;
    }


    // Start is called before the first frame update
    void Start()
    {
        count = 0f;
        closeCount = -99f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCompleted) return;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartSpawning();
        }

        if(closeCount >= count || Input.GetKeyDown(KeyCode.LeftShift))
        {
            isSpawn = false;
        }

        if(timer.currentTime <= 0 && count >= closeCount)
        {
            failedgame();
        }

        if(timer.currentTime > 0 && count == closeCount)
        {
            completeGame();
        }
    }

    void OnErrorWindowClose()
    {
        closeCount++;
    }

    public void StartSpawning()
    {
        //timer.targetTime = targetTime;
        isSpawn = true;
        timer.isCounting = true;
        StartCoroutine(SpawnWindow());
    }

    public void failedgame()
    {
        isFailed = true;
        timer.isCounting = false;
        gameManager.FailedGame();
    }

    public void completeGame()
    {
        isCompleted = true;
        timer.isCounting = false;
        notepadManager.CheeringParticle[0].Play();
        notepadManager.CheeringParticle[1].Play();
        notepadManager.CheeringParticle[2].Play();
        notepadManager.CheeringParticle[3].Play();
    }

    IEnumerator SpawnWindow()
    {
        yield return null;

        while(isSpawn)
        {
            yield return new WaitForSeconds(spawnTimer);

            if(closeCount >= count)
            {
                break;
            }
            
            //instantiate here
            Instantiate(errorWindow[Random.Range(0,2)],new Vector3 (Random.Range(minWidth,maxWidth),Random.Range(minHeight,maxHeight),minDepth),Quaternion.identity,parentCanvas);
            count += 1;

            if(closeCount < 0)
            {
                closeCount = 0;
            }
            
            minDepth -= 0.01f;
        }
    }

}
