using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PaintManager : MonoBehaviour
{
    public GameObject paintWindow;
    public Button paintButton;
    public PaintEnemy enemy;
    public bool endGame = false;

    public GameObject bombEffect;
    public Animator bombAnim;

    public NotePadManager notepadManager;

    private void Start()
    {
        bombEffect.SetActive(false);
    }

    void Update()
    {
        if(enemy.damageCount <= 0 && !endGame)
        {
            endPaintGame();
        }
    }

    public void openPaintWindow()
    {
        paintButton.interactable = false;
    }


    void endPaintGame()
    {
        endGame = true;
        paintButton.interactable = true;
        GameMonitor.GameCompleteTrigger(0);
        FindObjectOfType<AudioManager>().Play("cheering Sound");
        notepadManager.CheeringParticle[0].Play();
        notepadManager.CheeringParticle[1].Play();
        notepadManager.CheeringParticle[2].Play();
        notepadManager.CheeringParticle[3].Play();

        bombEffect.SetActive(true);
        bombAnim.Play("Bomb_Effect");
        FindObjectOfType<AudioManager>().Play("bigBomb Sound");
        StartCoroutine(SetOffBomb());
    }

    IEnumerator SetOffBomb()
    {
        yield return new WaitForSeconds(2);
        bombEffect.SetActive(false);
    }

}
