using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public event Action endGameStatus;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }
    public void EndGame()
    {
        endGameStatus();
    }
}
