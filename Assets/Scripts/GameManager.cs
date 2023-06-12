using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int starsToWin;

    public Action endGame_action;


    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    public void EndGame(Player winner)
    {
        string mssg = winner.HasInputAuthority ? "GANASTE" : "PERDISTE";
        Debug.Log(mssg);
        if (winner.HasInputAuthority) UIManager.instance.Victory();
        else UIManager.instance.Defeat();
        endGame_action();
    }
}
