using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class BugManager : MonoBehaviour
{
    public GameObject shieldErrorImage;
    public GameObject shieldNormalImage;
    public GameObject[] bugs;
    public GameObject[] insideBugs;
    public PesticideScript pesticide;
    public NotePadManager notepadManager;
    public GameObject bugDetectWindow;
    public bool isFinishing = false;

    public GameObject terrorVideo;
    public VideoPlayer videoPlayer;
    [SerializeField] string videoFileName;

    public bool isGeneratingBug = false;

    private void Start()
    {
        terrorVideo.SetActive(false);
        shieldErrorImage.SetActive(false);
        bugDetectWindow.SetActive(false);
    }

    public void StartBug()
    {
        string videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, videoFileName);
        videoPlayer.url = videoPath;

        terrorVideo.SetActive(true);

        FindObjectOfType<AudioManager>().Play("Terror Sound");
        FindObjectOfType<AudioManager>().Stop("BG Music");
        shieldErrorImage.SetActive(true);
        shieldNormalImage.SetActive(false);
        StartCoroutine(CallBug());
        StartCoroutine(CallDetector());
        isGeneratingBug = true;
    }

    public void CloseDetector()
    {
        bugDetectWindow.SetActive(false);
    }

    IEnumerator CallBug()
    {
        yield return new WaitForSeconds(0.5f);
        videoPlayer.Play();
        foreach (GameObject bug in bugs)
        {
            yield return new WaitForSeconds(0.3f);
            bug.SetActive(true);
        }
    }

    IEnumerator CallDetector()
    {
        yield return new WaitForSeconds(3);
        FindObjectOfType<AudioManager>().Play("Detector Sound");
        bugDetectWindow.SetActive(true);
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

        if(pesticide.destroyedNumber == insideBugs.Length && !isFinishing)
        {
            isFinishing = true;
            endGame();
            shieldErrorImage.SetActive(false);
            shieldNormalImage.SetActive(true);
        }
    }

    public void endGame()
    {
        terrorVideo.SetActive(false);
        videoPlayer.Play();
        FindObjectOfType<AudioManager>().Play("BG Music");
        FindObjectOfType<AudioManager>().Stop("Terror Sound");
        pesticide.isOnHand = false;
        pesticide.Object.gameObject.SetActive(false);

        GameMonitor.GameCompleteTrigger(4);
        FindObjectOfType<AudioManager>().Play("cheering Sound");
        notepadManager.CheeringParticle[0].Play();
        notepadManager.CheeringParticle[1].Play();
        notepadManager.CheeringParticle[2].Play();
        notepadManager.CheeringParticle[3].Play();
    }
}
