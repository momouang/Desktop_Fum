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
        //paintWindow.SetActive(true);
        paintButton.interactable = false;
    }


    void endPaintGame()
    {
        endGame = true;
        paintButton.interactable = true;
        notepadManager.CheeringParticle[0].Play();
        notepadManager.CheeringParticle[1].Play();
        notepadManager.CheeringParticle[2].Play();
        notepadManager.CheeringParticle[3].Play();

        bombEffect.SetActive(true);
        bombAnim.Play("Bomb_Effect");
        StartCoroutine(SetOffBomb());
    }

    IEnumerator SetOffBomb()
    {
        yield return new WaitForSeconds(2);
        bombEffect.SetActive(false);
    }

}
