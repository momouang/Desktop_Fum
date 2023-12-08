using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class VideoSlider : MonoBehaviour
{
    public Slider videoSlider;
    public float videoTime;
    public bool playing = false;

    public GameObject playButton;
    public GameObject pauseButton;

    private void Start()
    {
        videoSlider.value = 0;       
    }

    private void OnEnable()
    {   
        VideoPlayStart();
        videoSlider.maxValue = videoTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(videoSlider.value >= videoTime)
        {
            videoSlider.value = videoTime;
        }
    }

    public void VideoPlayStart()
    {
        StartCoroutine(VideoPlaying());
        playing = true;
    }

    public void Play()
    {
        var videoplayer = GetComponent<UnityEngine.Video.VideoPlayer>();
        videoplayer.Play();
        pauseButton.SetActive(true);
        playButton.SetActive(false);
    }

    public void Pause()
    {
        var videoplayer = GetComponent<UnityEngine.Video.VideoPlayer>();
        videoplayer.Pause();
        playButton.SetActive(true);
        pauseButton.SetActive(false);
    }

    IEnumerator VideoPlaying()
    {
        yield return new WaitForSeconds(3);
        var videoplayer = GetComponent<UnityEngine.Video.VideoPlayer>();

        videoplayer.Play();

        while (playing)
        {
            yield return new WaitForSeconds(1);
            videoSlider.value += 1;
        }
    }
}
