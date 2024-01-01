using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugManager : MonoBehaviour
{
    public GameObject[] bugs;
    public GameObject[] insideBugs;

    public bool isGeneratingBug = false;


    public void startBug()
    {
        StartCoroutine(CallBug());
        isGeneratingBug = true;
    }

    IEnumerator CallBug()
    {
        yield return new WaitForSeconds(0.5f);

        foreach(GameObject bug in bugs)
        {
            yield return new WaitForSeconds(0.3f);
            bug.SetActive(true);
        }
    }

    private void Update()
    {
        if(isGeneratingBug)
        {
            foreach(GameObject insidebugs in insideBugs)
            {
                insidebugs.SetActive(true);
            }
        }
    }
}
