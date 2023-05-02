using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PU_Star : PowerUps
{
    WinCondition _winCondition;

    public override void PU_Action()
    {
        _winCondition = _pl.GetComponent<WinCondition>();
        _winCondition.GainStar();
    }
}
