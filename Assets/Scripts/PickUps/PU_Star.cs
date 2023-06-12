using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PU_Star : PowerUps
{
    public override void PU_Action()
    {
        _pl.GainStar();
    }
}
