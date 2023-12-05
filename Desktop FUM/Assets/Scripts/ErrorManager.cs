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

    public float count;

    // Start is called before the first frame update
    void Start()
    {
        count = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartSpawning();
        }

        if(closeWindow.closeCount > count || Input.GetKeyDown(KeyCode.LeftShift))
        {
            isSpawn = false;
        }
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
            //instantiate here
            Instantiate(errorWindow[0],new Vector3 (Random.Range(minWidth,maxWidth),Random.Range(minHeight,maxHeight),minDepth),Quaternion.identity,parentCanvas);
            count += 1;
            
            minDepth -= 0.01f;
        }
    }

}
