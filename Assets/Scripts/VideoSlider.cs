using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Video;

public class VideoSlider : MonoBehaviour
{
    public Slider videoSlider;
    public float videoTime;
    public bool playing = false;
    public bool playFinished = false;

    [SerializeField] string videoFileName;

    public GameObject playButton;
    public GameObject pauseButton;

    public NotePadManager notepadManager;

    private void Start()
    {
        videoSlider.value = 0;       
    }

    private void OnEnable()
    {   
        VideoPlayStart();
        videoSlider.maxValue = videoTime;
    }

    void Update()
    {
        if(videoSlider.value >= videoTime && !playFinished)
        {
            playing = false;
            videoSlider.value = 0;
            playFinished = true;

            GameMonitor.GameCompleteTrigger(3);
            FindObjectOfType<AudioManager>().Play("cheering Sound");
            notepadManager.CheeringParticle[0].Play();
            notepadManager.CheeringParticle[1].Play();
            notepadManager.CheeringParticle[2].Play();
            notepadManager.CheeringParticle[3].Play();

        }
    }

    public void VideoPlayStart()
    {
        StartCoroutine(VideoPlaying());
        playing = true;
    }

    public void Play()
    {
        FindObjectOfType<AudioManager>().Play("BG Music");
        var videoplayer = GetComponent<UnityEngine.Video.VideoPlayer>();
        videoplayer.Play();
        pauseButton.SetActive(true);
        playButton.SetActive(false);
        playing = true;
    }

    public void Pause()
    {
        FindObjectOfType<AudioManager>().Pause("BG Music");
        var videoplayer = GetComponent<UnityEngine.Video.VideoPlayer>();
        videoplayer.Pause();
        playButton.SetActive(true);
        pauseButton.SetActive(false);
        playing = false;
    }

    IEnumerator VideoPlaying()
    {
        yield return new WaitForSeconds(1);
        VideoPlayer videoplayer = GetComponent<UnityEngine.Video.VideoPlayer>();
        if (videoplayer)
        {
            string videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, videoFileName);
            videoplayer.url = videoPath;
            videoplayer.Play();
        }

        while (true)
        {
            yield return new WaitForSeconds(1);
            if (playing)
            {
                videoSlider.value += 1;
            }
        }
    }
}
