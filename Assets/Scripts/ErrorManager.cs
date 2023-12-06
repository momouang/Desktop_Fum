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

    public Image[] errorWindow;

    public float count;
    public float closeCount;

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
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartSpawning();
        }

        if(closeCount >= count || Input.GetKeyDown(KeyCode.LeftShift))
        {
            isSpawn = false;
        }
    }

    void OnErrorWindowClose()
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
            if(closeCount >= count)
            {
                break;
            }    
            //instantiate here
            Instantiate(errorWindow[Random.Range(0,2)],new Vector3 (Random.Range(minWidth,maxWidth),Random.Range(minHeight,maxHeight),minDepth),Quaternion.identity,parentCanvas);
            count += 1;

            if(closeCount <0)
            {
                closeCount = 0;
            }
            
            minDepth -= 0.01f;
        }
    }

}
