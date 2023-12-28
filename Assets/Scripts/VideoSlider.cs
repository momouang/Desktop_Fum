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
    public bool playFinished = false;

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

    // Update is called once per frame
    void Update()
    {
        if(videoSlider.value >= videoTime && !playFinished)
        {
            videoSlider.value = videoTime;
            playFinished = true;

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
