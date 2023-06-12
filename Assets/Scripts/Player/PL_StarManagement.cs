using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PL_StarManagement
{
    Player _pl;

    public PL_StarManagement(Player pl)
    {
        _pl = pl;
    }

    int currentStars;

    public void GainStar()
    {
        Debug.Log("aaa");
        currentStars++;
        if (currentStars == GameManager.instance.starsToWin) Win();
    }

    void Win()
    {
        GameManager.instance.EndGame(_pl);
    }
}
