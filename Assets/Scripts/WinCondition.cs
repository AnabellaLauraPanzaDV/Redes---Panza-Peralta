using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class WinCondition : NetworkBehaviour
{
    public int currentStarCount;
    public int totalStar = 3;

    private void Start()
    {
        GameManager.instance.endGameStatus += WinOrLose;
    }

    public void GainStar()
    {
        currentStarCount++;
        Debug.Log(currentStarCount);
        if (currentStarCount >= totalStar) GameManager.instance.EndGame();
    }

    public void WinOrLose()
    {
        if (currentStarCount >= totalStar) Debug.Log("Gané");
        else Debug.Log("Perdí");
    }

}
