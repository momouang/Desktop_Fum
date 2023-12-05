using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ErrorManager : MonoBehaviour
{
    public float minWidth;
    public float maxWidth;
    public float minHeight;
    public float maxHeight;
    public float minDepth = 0;

    public Transform parentCanvas;
    public float timer;
    public bool isSpawn = false;

    public CloseWindow closeWindow;

    public Image[] errorWindow;

    public float count = 0, closeCount = -99;

    private void OnEnable()
    {
        //Use event from CloseWindow class to get a signal when a window is closed.
        CloseWindow.WindowClosed += OnErrorWindowClosed;
    }

    private void OnDisable()
    {
        //My jiiku is huge.
        CloseWindow.WindowClosed -= OnErrorWindowClosed;
    }

    // Start is called before the first frame update
    void Start()
    {
        count = 0f;
        closeCount = -99;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartSpawning();
        }

        if(closeCount >= count || Input.GetKeyDown(KeyCode.LeftShift))
        {
            //Do events when all ErrorWindows are closed here.
            isSpawn = false;
        }
    }

    void OnErrorWindowClosed()
    {
        closeCount++;
    }

    public void StartSpawning()
    {
        isSpawn = true;
        StartCoroutine(SpawnWindow());
    }

    IEnumerator SpawnWindow()
    {
        yield return null;

        while(isSpawn)
        {
            yield return new WaitForSeconds(1);
            if (closeCount >= count)    //Prevent accidently spawn a new ErrorWindow.
                break;

            //instantiate here
            Instantiate(errorWindow[0],new Vector3 (Random.Range(minWidth,maxWidth),Random.Range(minHeight,maxHeight),minDepth),Quaternion.identity,parentCanvas);
            count += 1;
            if (closeCount < 0)
                closeCount = 0;
            
            minDepth -= 0.01f;
        }
    }

}
